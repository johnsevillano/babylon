using System;
using System.Collections.Generic;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    public interface IProfileRepository
    {
        Guid Add(Profile profile);
        void Update(Profile profile);
        void Remove(Profile profile);
        IList<Profile> GetAllProfiles();
        Profile GetProfileByID(Guid id);
        Profile GetProfileByCredentials(string user, string password);
        IList<Profile> SearchProfiles(ProfileFilter filter);
        void AddContact(Guid id, Guid contactID);
        void AddContacts(Guid id, IList<Guid> contactIDs);
        IList<Profile> GetContacts(Guid id);
        void RemoveContact(Guid id, Guid contactID);
        void RemoveAllContacts(Guid id);
    }
}
