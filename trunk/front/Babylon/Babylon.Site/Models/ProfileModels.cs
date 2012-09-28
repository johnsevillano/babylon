using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Babylon.Site.Models
{

    public class Profile
    {
        [Editable(false)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "The Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password confirmation")]
        [Required(ErrorMessage = "The Password confirmation is required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation are different!")]
        public string PasswordConfirmation { get; set; }

        [StringLength(20, ErrorMessage = "The Name is too long!")]
        public string Name { get; set; }

        [StringLength(40, ErrorMessage = "The Surname is too long!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The Email is required!")]
        [StringLength(50, ErrorMessage = "The email address is too long!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please type in a valid email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please, enter a valid email address!")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public Address Address { get; set; }


        public Gender? Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        [Editable(false)]
        public DateTime? PictureUploadedOn { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated On")]
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }

        public IList<Profile> Contacts { get; set; }

    }

    public class Address
    {
        public string Street { get; set; }

        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

}