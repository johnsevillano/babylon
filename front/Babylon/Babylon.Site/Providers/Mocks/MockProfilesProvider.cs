using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers.Mocks
{
    public class MockProfilesProvider : IProfilesProvider
    {
        IList<Profile> _profilesCache = new List<Profile>();

        public MockProfilesProvider()
        {
            _profilesCache = new List<Profile>()
            {
                new Profile() {
                    Address = new Address() { City = "Dublin", PostalCode = "432", Street = "Malone St" },
                    Contacts = new List<Profile>(),
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Description = "Profile description",
                    Email = "gschlereth@gmail.com",
                    Gender = Gender.Male,
                    ID = Guid.NewGuid(),
                    Name = "Guillermo",
                    Password = "morpheus",
                    Picture = null,
                    PictureUploadedOn = DateTime.MinValue,
                    Surname = "Schlereth",
                    UpdatedOn = DateTime.Now,
                    Username = "gschlereth"
                }
            };
        }

        public Guid Add(Profile profileModel)
        {
            profileModel.ID = Guid.NewGuid();

            _profilesCache.Add(profileModel);

            return profileModel.ID;
        }

        public void AddContact(Guid id, Guid contactID)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);
            Profile contact = _profilesCache.First<Profile>(c => c.ID == contactID);

            profile.Contacts.Add(contact);
            contact.Contacts.Add(profile);
        }

        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);

            foreach (Guid contactID in contactIDs)
            {
                Profile contact = _profilesCache.First<Profile>(c => c.ID == contactID);

                profile.Contacts.Add(contact);
                contact.Contacts.Add(profile);
            }
        }

        public IList<Profile> GetAllProfiles()
        {
            return _profilesCache;
        }

        public IList<Profile> GetContacts(Guid id)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);

            return profile.Contacts;
        }

        public Profile GetProfileByCredentials(string user, string password)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.Username == user && p.Password == password);

            return profile;
        }

        public Profile GetProfileByID(Guid id)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);

            return profile;
        }

        public void Remove(Profile profileModel)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == profileModel.ID);

            _profilesCache.Remove(profile);
        }

        public void RemoveAllContacts(Guid id)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);

            profile.Contacts = new List<Profile>();
        }

        public void RemoveContact(Guid id, Guid contactID)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == id);

            Profile contact = profile.Contacts.First<Profile>(c => c.ID == contactID);

            profile.Contacts.Remove(contact);
        }

        public void Update(Profile profileModel)
        {
            Profile profile = _profilesCache.First<Profile>(p => p.ID == profileModel.ID);

            int index = _profilesCache.IndexOf(profile);

            _profilesCache.RemoveAt(index);
            _profilesCache.Insert(index, profileModel);
        }

    }
}