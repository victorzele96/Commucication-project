using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class LoginModel
    {
        [Key]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The Username contain only digits and letters.")]
        public String Username { get; set; }

        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The Password contain only digits and letters.")]
        public String UserPassword { get; set; }

        public bool RememberMe { get; internal set; }
    }
}