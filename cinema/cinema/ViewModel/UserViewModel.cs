using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.ViewModel
{
    public class UserViewModel
    {
        public loginModel login { get; }

        public List<loginModel> loginList { get; }
    }
}