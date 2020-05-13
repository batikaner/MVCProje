using MVCProje.DAL;
using MVCProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            using (UserContext ctx = new UserContext())
            {
                var list = ctx.Users.ToList();
                foreach (var item in list)
                {
                    if (item.Username   == user.Username  && item.Password ==user.Password )
                    {
                        ViewBag.use = item.Username;
                        //  TempData["usname"] = user.Username;
                        Session["userLogin"] = user.Username;
                        return RedirectToAction("../Main/Main");
                    }
                }
            }
            return View();
        }


        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(User usr)
        {
            using (UserContext ctx = new UserContext())
            {
                ctx.Users.Add(usr);
                int x = ctx.SaveChanges();
                if (x > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }

}