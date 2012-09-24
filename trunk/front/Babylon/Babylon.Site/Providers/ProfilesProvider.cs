using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Models = Babylon.Site.Models;
using Proxies = Babylon.Services.Proxies.ProfileServiceReference;


namespace Babylon.Site.Providers
{
    public class ProfilesProvider : Babylon.Site.Providers.IProfilesProvider
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
        /// <param name="profileModel"></param>
        /// <returns></returns>
        public Guid Add(Models.Profile profileModel)
        {
            Proxies.Profile profileProxy = ProfileModelToProxy(profileModel);

            string guid = _client.AddProfile(profileProxy);

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
        /// <param name="profileModel"></param>
        public void Update(Models.Profile profileModel)
        {
            Proxies.Profile profileProxy = ProfileModelToProxy(profileModel);

            _client.ModifyProfile(profileProxy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileModel"></param>
        public void Remove(Models.Profile profileModel)
        {
            _client.DeleteProfile(profileModel.ID.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Models.Profile> GetAllProfiles()
        {
            IList<Models.Profile> profileModels = new List<Models.Profile>();

            foreach (Proxies.Profile profileProxy in _client.GetAllProfiles())
            {
                profileModels.Add(ProfileProxyToModel(profileProxy));
            }

            return profileModels;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.Profile GetProfileByID(Guid id)
        {
            Proxies.Profile profileProxy = _client.GetProfileByID(id.ToString());

            return ProfileProxyToModel(profileProxy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Models.Profile GetProfileByCredentials(string user, string password)
        {
            Proxies.Profile profileProxy = _client.GetProfileByCredentials(user, password);

            return ProfileProxyToModel(profileProxy);
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
        public IList<Models.Profile> GetContacts(Guid id)
        {
            IList<Models.Profile> contactModels = new List<Models.Profile>();

            foreach (Proxies.Profile contactProxy in _client.GetContacts(id.ToString()))
            {
                contactModels.Add(ProfileProxyToModel(contactProxy));
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

        private Proxies.Profile ProfileModelToProxy(Models.Profile profileModel)
        {
            Proxies.Profile profileProxy =
                new Proxies.Profile()
                {
                    Address = new Proxies.Address()
                    {
                        Street = profileModel.Address.Street,
                        PostalCode = profileModel.Address.PostalCode,
                        City = profileModel.Address.City
                    },
                    CreatedOn = profileModel.CreatedOn,
                    DateOfBirth = profileModel.DateOfBirth,
                    Description = profileModel.Description,
                    Email = profileModel.Email,
                    Gender = profileModel.Gender == Models.Gender.Male ? Proxies.Gender.Male : Proxies.Gender.Female,
                    ID = profileModel.ID.ToString(),
                    Name = profileModel.Name,
                    Password = profileModel.Password,
                    Picture = profileModel.Picture,
                    PictureUploadedOn = profileModel.PictureUploadedOn,
                    Surname = profileModel.Surname,
                    UpdatedOn = profileModel.UpdatedOn,
                    Username = profileModel.Username
                };

            return profileProxy;
        }

        private Models.Profile ProfileProxyToModel(Proxies.Profile profileProxy)
        {
            Models.Profile profileModel =
                new Models.Profile()
                {
                    Address = new Models.Address()
                    {
                        Street = profileProxy.Address.Street,
                        PostalCode = profileProxy.Address.PostalCode,
                        City = profileProxy.Address.City
                    },
                    CreatedOn = profileProxy.CreatedOn,
                    DateOfBirth = profileProxy.DateOfBirth,
                    Description = profileProxy.Description,
                    Email = profileProxy.Email,
                    Gender = profileProxy.Gender == Proxies.Gender.Male ? Models.Gender.Male : Models.Gender.Female,
                    ID = Guid.Parse(profileProxy.ID),
                    Name = profileProxy.Name,
                    Password = profileProxy.Password,
                    Picture = profileProxy.Picture,
                    PictureUploadedOn = profileProxy.PictureUploadedOn,
                    Surname = profileProxy.Surname,
                    UpdatedOn = profileProxy.UpdatedOn,
                    Username = profileProxy.Username
                };

            return profileModel;
        }
    }

}