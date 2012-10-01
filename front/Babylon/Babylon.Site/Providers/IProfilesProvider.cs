using System;
using System.Collections.Generic;


namespace Babylon.Site.Providers
{
    public interface IProfilesProvider
    {
        Guid Add(Profile profile);
        void AddContact(Guid id, Guid contactID);
        void AddContacts(Guid id, IList<Guid> contactIDs);
        Guid CreateProfile(string username, string password, string email, string name, string surname);
        IList<Profile> GetAllProfiles();
        IList<Profile> GetContacts(Guid id);
        Profile GetProfileByCredentials(string user, string password);
        Profile GetProfileByID(Guid id);
        Profile GetProfileByUsername(string username);
        Profile GetProfileByEmail(string email);
        void Remove(Guid id);
        void RemoveAllContacts(Guid id);
        void RemoveContact(Guid id, Guid contactID);
        void Update(Profile profile);
    }

    public class Profile
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Gender? Gender { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? PictureUploadedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IList<Profile> Contacts { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

}
