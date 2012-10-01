using System;
using System.Collections.Generic;


namespace Babylon.Site.Providers
{
    public interface IGroupsProvider
    {
        Guid Add(Group group);
        void AddMember(Guid id, Guid memberID);
        void AddMembers(Guid id, IList<Guid> memberIDs);
        IList<Group> GetAllGroups();
        Group GetGroupByID(Guid id);
        IList<Profile> GetMembers(Guid id);
        void Remove(Group group);
        void RemoveAllMembers(Guid id);
        void RemoveMember(Guid id, Guid memberID);
        void Update(Group group);
    }

    public class Group
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Interests { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IList<Profile> Members { get; set; }
    }
}
