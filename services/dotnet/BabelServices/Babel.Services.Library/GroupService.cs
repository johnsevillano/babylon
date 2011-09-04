using System;
using System.Collections.Generic;
using System.ServiceModel;

using Babel.Services.Repositories;
using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services
{
    [ServiceBehavior(Namespace = "http://group.services.babel.com")]
    public class GroupService : IGroupService
    {
        private IGroupRepository _repository;

        private IGroupRepository Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new GroupRepository();
                }
                return _repository;
            }
        }

        public Guid AddGroup(Group group)
        {
            Repository.Add(group);

            return group.ID;
        }

        public Guid CreateGroup(string name, string description, string interests)
        {
            Group newGroup = new Group();
            newGroup.Name = name;
            newGroup.Description = description;
            newGroup.Interests = interests;

            Repository.Add(newGroup);

            return newGroup.ID;
        }

        public Group GetGroup(Guid id)
        {
            return Repository.GetGroupByID(id);
        }

        public IList<Group> GetAllGroups()
        {
            return Repository.GetAllGroups();
        }

        public void ModifyGroup(Group group)
        {
            Repository.Update(group);
        }

        public void DeleteGroup(Guid id)
        {
            Group group = Repository.GetGroupByID(id);
            Repository.Remove(group);
        }

        public IList<Group> SearchGroups(GroupFilter filter)
        {
            return Repository.SearchGroups(filter);
        }

        public void AddMember(Guid id, Guid memberID)
        {
            Repository.AddMember(id, memberID);
        }

        public void AddMembers(Guid id, IList<Guid> memberIDs)
        {
            Repository.AddMembers(id, memberIDs);
        }

        public IList<Profile> GetMembers(Guid id)
        {
            return Repository.GetMembers(id);
        }

        public void RemoveMember(Guid id, Guid memberID)
        {
            Repository.RemoveMember(id, memberID);
        }

        public void RemoveAllMembers(Guid id)
        {
            Repository.RemoveAllMembers(id);
        }
    }
}
