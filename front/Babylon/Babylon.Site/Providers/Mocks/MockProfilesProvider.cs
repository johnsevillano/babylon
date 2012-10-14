using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Babylon.Site.Providers.Mocks
{
    public class MockProfilesProvider : IProfilesProvider
    {
        private static MockProfilesProvider _instance;

        public static MockProfilesProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockProfilesProvider();
                }
                return _instance;
            }
        }

        private IList<Profile> _profilesCache = new List<Profile>();

        private MockProfilesProvider()
        {
            _profilesCache = new List<Profile>()
            {
                new Profile() {
                    Address = new Address() { City = "New York", PostalCode = "123", Street = "5th Avenue." },
                    Contacts = new List<Profile>(),
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Description = "Spiderman's newProfile description",
                    Email = "spiderman@gmail.com",
                    Gender = Gender.Male,
                    ID = Guid.NewGuid(),
                    Name = "Peter",
                    Password = "morpheus",
                    Photo = null,
                    PhotoUploadedOn = DateTime.MinValue,
                    Surname = "Parker",
                    UpdatedOn = DateTime.Now,
                    Username = "spiderman"
                },
                new Profile() {
                    Address = new Address() { City = "Gotham", PostalCode = "432", Street = "Darkness St." },
                    Contacts = new List<Profile>(),
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Description = "Batman's newProfile description",
                    Email = "batman@gmail.com",
                    Gender = Gender.Male,
                    ID = Guid.NewGuid(),
                    Name = "Bruce",
                    Password = "morpheus",
                    Photo = null,
                    PhotoUploadedOn = DateTime.MinValue,
                    Surname = "Wayne",
                    UpdatedOn = DateTime.Now,
                    Username = "batman"
                },
                new Profile() {
                    Address = new Address() { City = "Metropolis", PostalCode = "678", Street = "5th Avenue" },
                    Contacts = new List<Profile>(),
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Description = "Superman's newProfile description",
                    Email = "superman@gmail.com",
                    Gender = Gender.Male,
                    ID = Guid.NewGuid(),
                    Name = "Clark",
                    Password = "morpheus",
                    Photo = null,
                    PhotoUploadedOn = DateTime.MinValue,
                    Surname = "Kent",
                    UpdatedOn = DateTime.Now,
                    Username = "superman"
                }
            };

            LoadPhoto(_profilesCache[0], @"C:\Tmp\gschlereth.jpg", "image/jpeg");
        }

        public Guid Add(Profile profileModel)
        {
            profileModel.ID = Guid.NewGuid();

            _profilesCache.Add(profileModel);

            return profileModel.ID;
        }

        public void AddContact(Guid id, Guid contactID)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            if (profile == null)
            {
                return;
            }

            var contact = (from c in _profilesCache
                           where c.ID == contactID
                           select c)
                           .FirstOrDefault();

            if (contact == null)
            {
                return;
            }

            profile.Contacts.Add(contact);
            contact.Contacts.Add(profile);
        }

        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            if (profile == null)
            {
                return;
            }

            var contacts = from c in _profilesCache
                           where contactIDs.Contains(c.ID)
                           select c;

            foreach (Profile contact in contacts)
            {
                profile.Contacts.Add(contact);
                contact.Contacts.Add(profile);
            }
        }

        public Guid CreateProfile(string username, string password, string email, string name, string surname)
        {
            Profile newProfile = new Profile()
            {
                ID = Guid.NewGuid(),
                Username = username,
                Password = password,
                Email = email,
                Name = name,
                Surname = surname,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            _profilesCache.Add(newProfile);

            return newProfile.ID;
        }

        public IList<Profile> GetAllProfiles()
        {
            return _profilesCache;
        }

        public IList<Profile> GetContacts(Guid id)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            if (profile == null)
            {
                return null;
            }

            return profile.Contacts;
        }

        public Profile GetProfileByCredentials(string user, string password)
        {
            var profile = (from p in _profilesCache
                           where p.Username == user && p.Password == password
                           select p)
                           .FirstOrDefault();

            return profile;
        }

        public Profile GetProfileByID(Guid id)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            return profile;
        }

        public Profile GetProfileByUsername(string username)
        {
            var profile = (from p in _profilesCache
                           where p.Username == username
                           select p)
                           .FirstOrDefault();

            return profile;
        }

        public Profile GetProfileByEmail(string email)
        {
            var profile = (from p in _profilesCache
                           where p.Email == email
                           select p)
                           .FirstOrDefault();

            return profile;
        }

        public void Remove(Guid id)
        {
            var profile = (from p in _profilesCache
                            where p.ID == id
                            select p)
                            .FirstOrDefault();

            if (profile != null)
            {
                _profilesCache.Remove(profile);
            }
        }

        public void RemoveAllContacts(Guid id)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            if (profile != null)
            {
                profile.Contacts = new List<Profile>();
            }
        }

        public void RemoveContact(Guid id, Guid contactID)
        {
            var profile = (from p in _profilesCache
                           where p.ID == id
                           select p)
                           .FirstOrDefault();

            if (profile == null)
            {
                return;
            }

            var contact = (from c in profile.Contacts
                           where c.ID == contactID
                           select c)
                           .FirstOrDefault();

            if (contact == null)
            {
                return;
            }

            profile.Contacts.Remove(contact);
        }

        public void Update(Profile profileModel)
        {
            var profile = (from p in _profilesCache
                          where p.ID == profileModel.ID
                          select p)
                          .FirstOrDefault();

            int index = _profilesCache.IndexOf(profile);

            _profilesCache.RemoveAt(index);
            _profilesCache.Insert(index, profileModel);
        }

        private void LoadPhoto(Profile profile, string path, string type)
        {
            if (!System.IO.File.Exists(path))
            {
                return;
            }

            System.IO.FileStream fs = null;
            System.IO.BinaryReader br = null;

            try
            {
                fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                br = new System.IO.BinaryReader(fs);

                long fileSize = fs.Length;
                byte[] buffer = new byte[fileSize];
                br.Read(buffer, 0, (int)buffer.Length);

                br.Close();
                fs.Close();

                profile.Photo = buffer;
                profile.PhotoFilename = path;
                profile.PhotoMimeType = type;
                profile.PhotoSize = buffer.Length;
                profile.PhotoUploadedOn = DateTime.Now;
            }
            catch
            { }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

        }

    }
}