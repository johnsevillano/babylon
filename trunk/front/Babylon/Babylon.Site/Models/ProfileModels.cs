using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Babylon.Site.Models
{

    public class Profile
    {
        public Guid ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

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