﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class GroupsProvider : IGroupsProvider
    {
        public Guid Add(Babylon.Site.Models.Group group)
        {
            throw new NotImplementedException();
        }

        public void Update(Babylon.Site.Models.Group group)
        {
            throw new NotImplementedException();
        }

        public void Remove(Babylon.Site.Models.Group group)
        {
            throw new NotImplementedException();
        }

        public IList<Babylon.Site.Models.Group> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Babylon.Site.Models.Group GetGroupByID(Guid id)
        {
            throw new NotImplementedException();
        }

        //IList<Group> SearchGroups(GroupFilter filter);

        public void AddMember(Guid id, Guid memberID)
        {
            throw new NotImplementedException();
        }

        public void AddMembers(Guid id, IList<Guid> memberIDs)
        {
            throw new NotImplementedException();
        }

        public IList<Babylon.Site.Models.Profile> GetMembers(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(Guid id, Guid memberID)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllMembers(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}