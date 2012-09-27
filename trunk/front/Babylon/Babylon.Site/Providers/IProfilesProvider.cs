using System;

namespace Babylon.Site.Providers
{
    public interface IProfilesProvider
    {
        Guid Add(Babylon.Site.Models.Profile profileModel);
        void AddContact(Guid id, Guid contactID);
        void AddContacts(Guid id, System.Collections.Generic.IList<Guid> contactIDs);
        Guid CreateProfile(string username, string password, string email, string name, string surname);
        System.Collections.Generic.IList<Babylon.Site.Models.Profile> GetAllProfiles();
        System.Collections.Generic.IList<Babylon.Site.Models.Profile> GetContacts(Guid id);
        Babylon.Site.Models.Profile GetProfileByCredentials(string user, string password);
        Babylon.Site.Models.Profile GetProfileByID(Guid id);
        Babylon.Site.Models.Profile GetProfileByUsername(string username);
        Babylon.Site.Models.Profile GetProfileByEmail(string email);
        void Remove(Guid id);
        void RemoveAllContacts(Guid id);
        void RemoveContact(Guid id, Guid contactID);
        void Update(Babylon.Site.Models.Profile profileModel);
    }
}
