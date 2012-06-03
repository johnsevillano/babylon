using System;
using System.Collections.Generic;
using System.ServiceModel;

using Babel.Services.Repositories;
using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services
{
    [ServiceBehavior(Namespace = "http://babylon.com/services")]
    public class ProfileService : IProfileService
    {
        private IProfileRepository _repository;

        public Guid AddProfile(Profile profile)
        {
            Repository.Add(profile);

            return profile.ID;
        }

        public Guid CreateProfile(string username, string password, string email, string name, string surname)
        {
            Profile newProfile = new Profile();

            newProfile.Username = username;
            newProfile.Password = password;
            newProfile.Email = email;
            newProfile.Name = name;
            newProfile.Surname = surname;

            Repository.Add(newProfile);

            return newProfile.ID;
        }

        public Profile GetProfile(string username, string password)
        {
            return Repository.GetProfileByCredentials(username, password);
        }

        public Profile GetProfile(Guid id)
        {
            return Repository.GetProfileByID(id);
        }

        public IList<Profile> GetAllProfiles()
        {
            return Repository.GetAllProfiles();
        }

        public void ModifyProfile(Profile profile)
        {
            Repository.Update(profile);
        }

        public void DeleteProfile(Guid id)
        {
            Profile profile = Repository.GetProfileByID(id);
            Repository.Remove(profile);
        }

        public IList<Profile> SearchProfiles(ProfileFilter filter)
        {
            return Repository.SearchProfiles(filter);
        }

        public void AddContact(Guid id, Guid contactID)
        {
            Repository.AddContact(id, contactID);
        }

        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            Repository.AddContacts(id, contactIDs);
        }

        public IList<Profile> GetContacts(Guid id)
        {
            return Repository.GetContacts(id);
        }

        public void RemoveContact(Guid id, Guid contactID)
        {
            Repository.RemoveContact(id, contactID);
        }

        public void RemoveAllContacts(Guid id)
        {
            Repository.RemoveAllContacts(id);
        }

        private IProfileRepository Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Babel.Services.Repositories.ProfileRepository();
                }
                return _repository;
            }
        }
    }
}
