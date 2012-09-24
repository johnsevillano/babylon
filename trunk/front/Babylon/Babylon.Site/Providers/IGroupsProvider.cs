using System;
namespace Babylon.Site.Providers
{
    public interface IGroupsProvider
    {
        Guid Add(Babylon.Site.Models.Group group);
        void AddMember(Guid id, Guid memberID);
        void AddMembers(Guid id, System.Collections.Generic.IList<Guid> memberIDs);
        System.Collections.Generic.IList<Babylon.Site.Models.Group> GetAllGroups();
        Babylon.Site.Models.Group GetGroupByID(Guid id);
        System.Collections.Generic.IList<Babylon.Site.Models.Profile> GetMembers(Guid id);
        void Remove(Babylon.Site.Models.Group group);
        void RemoveAllMembers(Guid id);
        void RemoveMember(Guid id, Guid memberID);
        void Update(Babylon.Site.Models.Group group);
    }
}
