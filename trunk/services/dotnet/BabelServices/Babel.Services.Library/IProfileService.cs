using System;
using System.Collections.Generic;
using System.ServiceModel;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services
{

    [ServiceContract(Namespace = "http://profile.services.babel.com")]
    public interface IProfileService
    {
        [OperationContract]
        Guid AddProfile(Profile profile);

        [OperationContract]
        Guid CreateProfile(string username, string password, string email, string name, string surname);

        [OperationContract(Name = "GetProfileByCredentials")]
        Profile GetProfile(string username, string password);

        [OperationContract(Name = "GetProfileByID")]
        Profile GetProfile(Guid id);

        [OperationContract]
        IList<Profile> GetAllProfiles();

        [OperationContract]
        void ModifyProfile(Profile profile);

        [OperationContract]
        void DeleteProfile(Guid id);

        [OperationContract]
        IList<Profile> SearchProfiles(ProfileFilter filter);

        [OperationContract]
        void AddContact(Guid id, Guid contactID);

        [OperationContract]
        void AddContacts(Guid id, IList<Guid> contactIDs);

        [OperationContract]
        IList<Profile> GetContacts(Guid id);

        [OperationContract]
        void RemoveContact(Guid id, Guid contactID);

        [OperationContract]
        void RemoveAllContacts(Guid id);
    }
}
