using MVCProje.DAL;
using MVCProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class MainController : Controller
    {

        // GET: Main
        public ActionResult Index()
        {
            if (Session["userLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            var lst = TempData["usname"];
            return View();
        }

        public ActionResult Main()
        {
            if (Session["userLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("../Home/Index");
        }



        public ActionResult NewSerie()
        {
            if (Session["userLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult NewSerie(Serie tv)
        {
            using (UserContext ctx= new UserContext())
            {
                ctx.Series.Add(tv);
                int x= ctx.SaveChanges();
                if (x>0)
                {
                    return RedirectToAction("/Main/Main");
                }
            }
            return View();
        }
    }
}