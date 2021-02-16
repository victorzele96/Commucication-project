using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class RegistrationModel
    {
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "The First Name contain only letters.")]
        public String FirstName { get; set; }

 
        [RegularExpression("^[a-zA-Z][a-zA-Z]*$", ErrorMessage = "The Last Name contain only letters.")]
        public String LastName { get; set; }

        [Key]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "The Username contain only digits and letters.")]
        public String Username { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid E-mail adress")]
        public String Email { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone Number must contain 10 digits.")]
        public String UserNumber { get; set; }

        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The Password contain only digits and letters.")]
        public String UserPassword { get; set; }
    }
}