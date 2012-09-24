using System;

namespace Babylon.Site.Providers
{
    public interface IProfilesProvider
    {
        Guid Add(Babylon.Site.Models.Profile profileModel);
        void AddContact(Guid id, Guid contactID);
        void AddContacts(Guid id, System.Collections.Generic.IList<Guid> contactIDs);
        System.Collections.Generic.IList<Babylon.Site.Models.Profile> GetAllProfiles();
        System.Collections.Generic.IList<Babylon.Site.Models.Profile> GetContacts(Guid id);
        Babylon.Site.Models.Profile GetProfileByCredentials(string user, string password);
        Babylon.Site.Models.Profile GetProfileByID(Guid id);
        void Remove(Babylon.Site.Models.Profile profileModel);
        void RemoveAllContacts(Guid id);
        void RemoveContact(Guid id, Guid contactID);
        void Update(Babylon.Site.Models.Profile profileModel);
    }
}
