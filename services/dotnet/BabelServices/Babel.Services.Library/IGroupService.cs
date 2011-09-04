using System;
using System.Collections.Generic;
using System.ServiceModel;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services
{
    [ServiceContract(Namespace = "http://group.services.babel.com")]
    public interface IGroupService
    {
        [OperationContract]
        Guid AddGroup(Group group);

        [OperationContract]
        Guid CreateGroup(string name, string description, string interests);

        [OperationContract]
        Group GetGroup(Guid id);

        [OperationContract]
        IList<Group> GetAllGroups();

        [OperationContract]
        void ModifyGroup(Group group);

        [OperationContract]
        void DeleteGroup(Guid id);

        [OperationContract]
        IList<Group> SearchGroups(GroupFilter filter);

        [OperationContract]
        void AddMember(Guid id, Guid memberID);

        [OperationContract]
        void AddMembers(Guid id, IList<Guid> memberIDs);

        [OperationContract]
        IList<Profile> GetMembers(Guid id);

        [OperationContract]
        void RemoveMember(Guid id, Guid memberID);

        [OperationContract]
        void RemoveAllMembers(Guid id);
    }
}
