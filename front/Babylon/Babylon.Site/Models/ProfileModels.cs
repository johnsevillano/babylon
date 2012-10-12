using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using Babylon.Site.Providers;
using Babylon.Site.Common;


namespace Babylon.Site.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel() {}

        public ProfileViewModel(Profile profile)
        {
            ID = profile.ID;
            Username = profile.Username;
            Name = profile.Name;
            Surname = profile.Surname;
            Email = profile.Email;
            DateOfBirth = profile.DateOfBirth;
            Address = new Address()
            {
                Street = profile.Address.Street,
                City = profile.Address.City,
                PostalCode = profile.Address.PostalCode
            };
            Gender = profile.Gender;
            Description = profile.Description;
            CreatedOn = profile.CreatedOn;
            UpdatedOn = profile.UpdatedOn;
        }

        [Editable(false)]
        public Guid ID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public Address Address { get; set; }

        public Gender? Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }
    }

    public class ProfileInputModel
    {
        public ProfileInputModel() {}

        public ProfileInputModel(Profile profile)
        {
            ID = profile.ID;
            Username = profile.Username;
            Name = profile.Name;
            Surname = profile.Surname;
            Email = profile.Email;
            DateOfBirth = profile.DateOfBirth;
            Address = new Address()
            {
                Street = profile.Address.Street,
                City = profile.Address.City,
                PostalCode = profile.Address.PostalCode
            };
            Gender = profile.Gender;
            Description = profile.Description;
        }

        [Editable(false)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "The Username is required!")]
        public string Username { get; set; }

        [Display(Name = "Change Password")]
        public bool ChangePassword { get; set; }

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

        [FileSize(102400)]
        [FileTypes("png,jpg,gif")]
        public HttpPostedFileBase Photo { get; set; }

        public IList<Profile> Contacts { get; set; }

    }

}