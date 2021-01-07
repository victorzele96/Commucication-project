using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cinema.Dal;
using cinema.ViewModel;

namespace cinema.Controllers
{
    public class mainController : Controller
    {
        // GET: cinema
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult registration()
        {
            return View("registration");
        }

        public ActionResult saveDetails(registrationModel reg)
        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                dal.Registration.Add(reg);
                dal.SaveChanges();
                return View("mainPage");
            }
            return View("registration");
        }

        public ActionResult userLogin(loginModel log)
        {                           // should addd here tblAdmin and check if this user is admin (victor or arie)
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                UserViewModel uvm = new UserViewModel(); // uvm - user view model
                List<registrationModel> loginM = dal.Registration.ToList<registrationModel>();
                foreach(registrationModel regModel in loginM)
                    if(log.Username.Equals(regModel.Username) && log.UserPassword == regModel.UserPassword)
                        return View("mainPage");
            }
            return View("login");
        }

        public ActionResult about()
        {
            return View();
        }
    }
}