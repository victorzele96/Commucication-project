using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cinema.Controllers
{
    public class cinemaController : Controller
    {
        // GET: cinema
        public ActionResult MainPage()
        {
            return View();
        }
    }
}