using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class ProfilesProvider
    {
        public Guid Add(Profile profile)
        {
            throw new NotImplementedException();
        }

        public void Update(Profile profile)
        {
            throw new NotImplementedException();
        }

        public void Remove(Profile profile)
        {
            throw new NotImplementedException();
        }

        public IList<Profile> GetAllProfiles()
        {
            throw new NotImplementedException();
        }

        public Profile GetProfileByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Profile GetProfileByCredentials(string user, string password)
        {
            throw new NotImplementedException();
        }

        //IList<Profile> SearchProfiles(ProfileFilter filter);

        public void AddContact(Guid id, Guid contactID)
        {
            throw new NotImplementedException();
        }

        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            throw new NotImplementedException();
        }

        public IList<Profile> GetContacts(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(Guid id, Guid contactID)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllContacts(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}