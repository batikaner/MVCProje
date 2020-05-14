using MVCProje.DAL;
using MVCProje.Models;
using MVCProje.Models.SerieViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View();


        }

        public ActionResult Main()
        {
            SerieViewModels show = new SerieViewModels();
            if (Session["userLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            using (UserContext ctx = new UserContext())
            {
                show.tvserie = ctx.Series.ToList();
                //var tvs = ctx.Series.ToList();
                return View(show);
            }
            
        }

        public ActionResult Delete(int? id)
        {
            SerieViewModels show = new SerieViewModels();
            using (UserContext ctx= new UserContext())
            {
                var test = ctx.Series.Find(id);
                ctx.Series.Remove(test);
                ctx.SaveChanges();


                return RedirectToAction("/Main/Main");
            }

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


     
        public ActionResult Update(int? id)
        {
            if (Session["userLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            using (UserContext ctx = new UserContext())
            {
                var show = ctx.Series.Find(id);
                return View(show);
            }
        }


        [HttpPost]
        public ActionResult Update(Serie sh)
        {
            using (UserContext ctx= new UserContext())
            {
                ctx.Entry(sh).State=EntityState.Modified;
                int x = ctx.SaveChanges();
                if (x>0)
                {
                    return RedirectToAction("/Main/Main");
                }
            }
            return View(sh);
        }
       
    }
}