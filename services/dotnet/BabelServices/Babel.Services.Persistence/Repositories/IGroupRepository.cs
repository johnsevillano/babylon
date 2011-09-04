using System;
using System.Collections.Generic;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    public interface IGroupRepository
    {
        Guid Add(Group group);
        void Update(Group group);
        void Remove(Group group);
        IList<Group> GetAllGroups();
        Group GetGroupByID(Guid id);
        IList<Group> SearchGroups(GroupFilter filter);
        void AddMember(Guid id, Guid memberID);
        void AddMembers(Guid id, IList<Guid> memberIDs);
        IList<Profile> GetMembers(Guid id);
        void RemoveMember(Guid id, Guid memberID);
        void RemoveAllMembers(Guid id);
    }
}
