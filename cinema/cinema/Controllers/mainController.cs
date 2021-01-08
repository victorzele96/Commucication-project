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
        public ActionResult MainPage(String name)
        {
            if(name == null)
                ViewBag.name = "Guest";
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
        {
            String name;
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                //UserViewModel uvm = new UserViewModel(); // uvm - user view model
                List<registrationModel> loginM = dal.Registration.ToList<registrationModel>();
                foreach(registrationModel regModel in loginM)
                    if(log.Username.Equals(regModel.Username) && log.UserPassword == regModel.UserPassword)
                    {
                        name = regModel.FirstName;
                        name = char.ToUpper(name[0]) + name.Substring(1);
                        ViewBag.name = name;
                        return View("mainPage");
                    }
                AdminDal admin_dal = new AdminDal();
                List<AdminModel> loginA = admin_dal.adminLogin.ToList<AdminModel>();
                foreach (AdminModel admLog in loginA)
                {
                    name = admLog.AdminName;
                    if (name != string.Empty && char.IsUpper(name[0]))
                    {
                        name = char.ToLower(name[0]) + name.Substring(1);
                    }
                    if (log.Username.Equals(name) && log.UserPassword == admLog.AdminPassword)
                    {
                        ViewBag.name = admLog.AdminName;
                        return View("mainPage");
                    }
                }
            }
            return View("login");
        }

        public ActionResult about()
        {
            return View();
        }
        public ActionResult edit()
        {
            return View();
        }
    }
}