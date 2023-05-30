using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudSignup.Models
{
    public class Signup_page
    {
        [Display(Name = "UserID")]
        public int UserId { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "EmailAddress")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }



    }
}