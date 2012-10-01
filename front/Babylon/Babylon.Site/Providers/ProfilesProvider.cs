using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Proxies = Babylon.Services.Proxies.ProfileServiceReference;


namespace Babylon.Site.Providers
{
    public class ProfilesProvider : IProfilesProvider
    {
        private Proxies.ProfileServiceClient _client;

        /// <summary>
        /// 
        /// </summary>
        public ProfilesProvider()
        {
            _client = new Proxies.ProfileServiceClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public ProfilesProvider(Proxies.ProfileServiceClient proxy)
        {
            _client = proxy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProfile"></param>
        /// <returns></returns>
        public Guid Add(Profile profile)
        {
            Proxies.Profile proxy = ProfileToProxy(profile);

            string guid = _client.AddProfile(proxy);

            Guid result;
            if (Guid.TryParse(guid, out result))
            {
                return result;
            }
            else
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public Guid CreateProfile(string username, string password, string email, string name, string surname)
        {
            string guid = _client.CreateProfile(username, password, email, name, surname);

            return Guid.Parse(guid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileModel"></param>
        public void Update(Profile profile)
        {
            Proxies.Profile proxy = ProfileToProxy(profile);

            _client.ModifyProfile(proxy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileModel"></param>
        public void Remove(Guid id)
        {
            _client.DeleteProfile(id.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Profile> GetAllProfiles()
        {
            IList<Profile> profileModels = new List<Profile>();

            foreach (Proxies.Profile proxy in _client.GetAllProfiles())
            {
                profileModels.Add(ProxyToProfile(proxy));
            }

            return profileModels;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Profile GetProfileByID(Guid id)
        {
            Proxies.Profile proxy = _client.GetProfileByID(id.ToString());

            return ProxyToProfile(proxy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Profile GetProfileByUsername(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Profile GetProfileByCredentials(string user, string password)
        {
            Proxies.Profile proxy = _client.GetProfileByCredentials(user, password);

            return ProxyToProfile(proxy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Profile GetProfileByEmail(string email)
        {
            throw new NotImplementedException();
        }

        //IList<Profile> SearchProfiles(ProfileFilter filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactID"></param>
        public void AddContact(Guid id, Guid contactID)
        {
            _client.AddContact(id.ToString(), contactID.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactIDs"></param>
        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            Proxies.ArrayOfguid guids = new Proxies.ArrayOfguid();

            foreach (Guid guid in contactIDs)
            {
                guids.Add(guid.ToString());
            }

            _client.AddContacts(id.ToString(), guids);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Profile> GetContacts(Guid id)
        {
            IList<Profile> contactModels = new List<Profile>();

            foreach (Proxies.Profile contactProxy in _client.GetContacts(id.ToString()))
            {
                contactModels.Add(ProxyToProfile(contactProxy));
            }

            return contactModels;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactID"></param>
        public void RemoveContact(Guid id, Guid contactID)
        {
            _client.RemoveContact(id.ToString(), contactID.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAllContacts(Guid id)
        {
            _client.RemoveAllContacts(id.ToString());
        }

        private Proxies.Profile ProfileToProxy(Profile profile)
        {
            Proxies.Profile profileProxy =
                new Proxies.Profile()
                {
                    Address = new Proxies.Address()
                    {
                        Street = profile.Address.Street,
                        PostalCode = profile.Address.PostalCode,
                        City = profile.Address.City
                    },
                    CreatedOn = profile.CreatedOn,
                    DateOfBirth = profile.DateOfBirth,
                    Description = profile.Description,
                    Email = profile.Email,
                    Gender = profile.Gender == Gender.Male ? Proxies.Gender.Male : Proxies.Gender.Female,
                    ID = profile.ID.ToString(),
                    Name = profile.Name,
                    Password = profile.Password,
                    Picture = profile.Picture,
                    PictureUploadedOn = profile.PictureUploadedOn,
                    Surname = profile.Surname,
                    UpdatedOn = profile.UpdatedOn,
                    Username = profile.Username
                };

            return profileProxy;
        }

        private Profile ProxyToProfile(Proxies.Profile proxy)
        {
            Profile profile =
                new Profile()
                {
                    Address = new Address()
                    {
                        Street = proxy.Address.Street,
                        PostalCode = proxy.Address.PostalCode,
                        City = proxy.Address.City
                    },
                    CreatedOn = proxy.CreatedOn,
                    DateOfBirth = proxy.DateOfBirth,
                    Description = proxy.Description,
                    Email = proxy.Email,
                    Gender = proxy.Gender == Proxies.Gender.Male ? Gender.Male : Gender.Female,
                    ID = Guid.Parse(proxy.ID),
                    Name = proxy.Name,
                    Password = proxy.Password,
                    Picture = proxy.Picture,
                    PictureUploadedOn = proxy.PictureUploadedOn,
                    Surname = proxy.Surname,
                    UpdatedOn = proxy.UpdatedOn,
                    Username = proxy.Username
                };

            return profile;
        }
    }

}