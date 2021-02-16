using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cinema.Models;

namespace cinema.ViewModel
{
    public class UserViewModel
    {
        public RegistrationModel regModel { get; }

        public List<RegistrationModel> regModelList { get; }
    }
}