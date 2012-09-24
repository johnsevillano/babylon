﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;



namespace Babylon.Site.Providers.Mocks
{
    public class MockGroupsProvider : IGroupsProvider
    {
        private IList<Group> _groupsCache = new List<Group>();

        public Guid Add(Group group)
        {
            throw new NotImplementedException();
        }

        public void AddMember(Guid id, Guid memberID)
        {
            throw new NotImplementedException();
        }

        public void AddMembers(Guid id, IList<Guid> memberIDs)
        {
            throw new NotImplementedException();
        }

        public IList<Group> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Group GetGroupByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Profile> GetMembers(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Group group)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllMembers(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(Guid id, Guid memberID)
        {
            throw new NotImplementedException();
        }

        public void Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}