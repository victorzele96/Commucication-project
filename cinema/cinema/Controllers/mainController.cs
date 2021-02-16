using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cinema.Dal;
using cinema.ViewModel;
using System.Reflection;
using System.Web.Security;
using WebMatrix.WebData;
using cinema.Filters;
using System.Globalization;

namespace cinema.Controllers
{
    [InitializeSimpleMembership]
    public class mainController : Controller
    {
        // GET: cinema
        public ActionResult logout() { WebSecurity.Logout(); return RedirectToAction("MainPage"); }
        public ActionResult MainPage(ProductViewModel listModel, String sortBy)
        {
            ViewBag.name = "Guest";
            ProductViewModel list = new ProductViewModel();

            if (listModel.productModelList != null)
                list.productModelList = listModel.productModelList;
            else
                list = PVM();

            if (sortBy != null)
            {
                if (sortBy.Equals("price increase"))
                {
                    list.productModelList = list.productModelList.OrderBy(o => (o.MoviePrice)).ToList<ProductModel>();
                }

                if (sortBy.Equals("price decrease"))
                {
                    list.productModelList = list.productModelList.OrderBy(o => (o.MoviePrice)).ToList<ProductModel>();
                    list.productModelList.Reverse();
                }

                if (sortBy.Equals("most popular"))
                {
                    //Bonus or wnat i like to see more !!! By action Movie
                }

                if (sortBy.Equals("category"))
                {
                    ProductDal productdal = new ProductDal();
                    ProductViewModel pvm = new ProductViewModel();              //pvm product view model
                    pvm.productModelList = productdal.ProductData.ToList<ProductModel>();
                    pvm.productModel = new ProductModel();
                    List<ProductModel> productList = new List<ProductModel>();

                    String type = Request.Form["some"];
                    if (type != "")
                    {
                        foreach (ProductModel ele in pvm.productModelList)
                        {
                            String[] words = ele.MovieGenre.Split(' ');
                            if (words.Contains(type) || words.Contains(char.ToLower(type[0]) + type.Substring(1)))
                                productList.Add(ele);
                        }
                        pvm.productModelList = productList;
                    }
                    list = pvm;
                }

                if (sortBy.Equals("18+"))
                {
                    ProductDal productdal = new ProductDal();
                    ProductViewModel pvm = new ProductViewModel();              //pvm product view model
                    List<ProductModel> productList = productdal.ProductData.ToList<ProductModel>();
                    pvm.productModel = new ProductModel();
                    productList = (from data in productdal.ProductData where data.MovieAgeLimit >= 18 select data).ToList<ProductModel>();
                    pvm.productModelList = productList;
                    list = pvm;
                }

                if (sortBy.Equals("price range"))
                {
                    String price = Request.Form["priceRange"];
                    ProductDal productdal = new ProductDal();
                    ProductViewModel pvm = new ProductViewModel();              //pvm product view model
                    List<ProductModel> productList = productdal.ProductData.ToList<ProductModel>();
                    pvm.productModel = new ProductModel();
                    String str = "";
                    for (int j = 0; j < price.Length - 1; j++)
                        str += price[j];

                    int p = Int32.Parse(str);
                    productList = (from data in productdal.ProductData where data.MoviePrice <= p select data).ToList<ProductModel>();
                    pvm.productModelList = productList;
                    list = pvm;

                }

            }

            return View(list);
        }
        public ActionResult login() { return View(); }
        public ActionResult registration() { return View(); }
        public ActionResult about() { return View(); }
        public ActionResult addMovie() { return View(); }
        public ActionResult edit() { return View(); }
        public ActionResult updateMovie() { return View(PVM()); }
        public ActionResult removeMovie() { return View(PVM()); }


        public ProductViewModel PVM()
        {
            ProductDal productdal = new ProductDal();
            ProductViewModel pvm = new ProductViewModel();              //pvm product view model
            List<ProductModel> productList = productdal.ProductData.ToList<ProductModel>();
            pvm.productModel = new ProductModel();
            pvm.productModelList = productList;
            return pvm;
        }

        public OrderViewModel OVM()
        {
            OrderDal orderdal = new OrderDal();
            OrderViewModel ovm = new OrderViewModel();              //pvm product view model
            List<OrderModel> orderList = orderdal.OrderData.ToList<OrderModel>();
            ovm.orderModel = new OrderModel();
            ovm.orderModelList = orderList;
            return ovm;
        }

        public ActionResult saveDetails(RegistrationModel reg)
        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                dal.Registration.Add(reg);
                dal.SaveChanges();

                WebSecurity.CreateUserAndAccount(reg.Username, reg.UserPassword, true);

                return View("mainPage", PVM());
            }
            return View("registration");
        }

        public ActionResult userLogin(LoginModel log)
        {
            UserDal dal = new UserDal();
            List<RegistrationModel> loginM = dal.Registration.ToList<RegistrationModel>();
            foreach (RegistrationModel regModel in loginM)
                if (log.Username.Equals(regModel.Username) && log.UserPassword == regModel.UserPassword)
                {

                    FormsAuthentication.SetAuthCookie(log.Username, true);
                    WebSecurity.Login(log.Username, log.UserPassword, persistCookie: log.RememberMe);
                    return RedirectToAction("MainPage");
                }

            return View("login");
        }

        public ActionResult saveMovieDetails(ProductModel edit)
        {
            edit.SeatsNum = edit.SeatsNum * 12;
            if (ModelState.IsValid)
            {
                ProductDal dal = new ProductDal();
                dal.ProductData.Add(edit);
                dal.SaveChanges();
                return View("edit");
            }
            return View("addMovie");
        }

        public ActionResult deleteMovieFromDb()
        {
            ProductDal productdal = new ProductDal();
            List<ProductModel> productList = productdal.ProductData.ToList<ProductModel>();
            String str = Request.Form["demo"];
            foreach (ProductModel movie in productList)
            {
                if (movie.MovieName.Equals(str))
                {
                    //delete this line from db
                    productdal.ProductData.Remove(movie);
                    productdal.SaveChanges();
                }
            }
            return View("edit");
        }

        public ActionResult updateMovieDetails(ProductModel check)
        {
            check.SeatsNum = check.SeatsNum * 12;

            ProductDal productdal = new ProductDal();
            List<ProductModel> productList = productdal.ProductData.ToList<ProductModel>();
            foreach (ProductModel movie in productList)
            {
                if (movie.MovieName.Equals(check.MovieName))
                {
                    //delete this line from db
                    productdal.ProductData.Remove(movie);
                    productdal.SaveChanges();
                }
            }
            if (ModelState.IsValid)
            {
                ProductDal dal = new ProductDal();
                dal.ProductData.Add(check);
                dal.SaveChanges();
                return View("edit");
            }
            return View("edit");
        }

        public ActionResult moviePage(String sortByMovie)
        {
            ProductViewModel list = new ProductViewModel();
            list.productModelList = new List<ProductModel>();
            list.productModel = new ProductModel();
            ProductViewModel lst = PVM();
            ViewBag.nameOfMovie = "";

            foreach (ProductModel ele in lst.productModelList)
            {
                if (ele.MovieName.Equals(sortByMovie))
                {
                    list.productModelList.Add(ele);
                    ViewBag.nameOfMovie = ele.MovieName;
                }
            }

            return View(list);
        }
        public ActionResult seats(String MovieName, String MovieImg, String MoviePrice, String HallNum, String SeatsNum, String MovieDayPlay)
        {
            ProductViewModel lst = PVM();
            foreach(ProductModel ele in lst.productModelList)
            {
                if (ele.MovieName.Equals(MovieName))
                {
                    ViewBag.movieName = MovieName;
                    ViewBag.movieImg = MovieImg;
                    ViewBag.moviePrice = MoviePrice;
                    ViewBag.HallNum = HallNum;
                    ViewBag.SeatsNum = SeatsNum;
                    ViewBag.MovieDayPlay = MovieDayPlay;
                }
            }

            return View(OVM());
        }

        public ActionResult cart(String MovieName, String MovieImg, String MoviePrice, String HallNum, String SeatsNum, String MovieDayPlay) //seats = ,  String seats, 
        {
            ProductViewModel lst = PVM();

            String seatPlaces = Request.Form["x"];
            String[] seats = seatPlaces.Split(',');
            ViewBag.numTickets = seats.Count();
            ViewBag.seatPlaces = seatPlaces;
            ViewBag.movieName = MovieName;
            ViewBag.movieImg = MovieImg;
            ViewBag.moviePrice = MoviePrice;
            ViewBag.HallNum = HallNum;
            ViewBag.SeatsNum = SeatsNum;
            ViewBag.MovieDayPlay = MovieDayPlay;

            return View();
        }

        public ActionResult order(String HallNum, String Seats, String MovieName, String MovieDayPlay, String Price)
        {
            OrderDal dal = new OrderDal();
            OrderModel order = new OrderModel();
            order.Hall = Int32.Parse(HallNum);
            order.Seat = Seats;
            order.MovieName = MovieName;
            String[] str = MovieDayPlay.Split(')');
            String name = Request.Form["cardholder"];
            String[] firstAndLast = name.Split(' ');
            order.FirstName = firstAndLast[0];
            order.LastName = firstAndLast[1];
            order.MovieDatePlay = DateTime.Parse(str[0]);
            order.Price = Int32.Parse(Price);
            if (ModelState.IsValid)
            {
                dal.OrderData.Add(order);
                dal.SaveChanges();
            }
            return RedirectToAction("MainPage");
        }
    }
}