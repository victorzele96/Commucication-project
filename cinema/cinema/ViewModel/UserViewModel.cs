using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.ViewModel
{
    public class UserViewModel
    {
        public registrationModel regModel { get; }

        public List<registrationModel> regModelList { get; }
    }
}