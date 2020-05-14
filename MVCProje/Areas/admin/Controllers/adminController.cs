using MVCProje.DAL;
using MVCProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Areas.admin.Controllers
{
    public class adminController : Controller
    {
        // GET: admin/admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            if (Session["admin"]==null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            using (UserContext ctx = new UserContext())
            {
                var list = ctx.Users.ToList();
                foreach (var item in list)
                {
                    if (item.Username == user.Username && item.Password == user.Password && item.role==1)
                    {

                        Session["admin"] = user.Username;
                        return RedirectToAction("List");
                    }
                }
            }
            return RedirectToAction("Index");
        }



        public ActionResult List()
        {
            if (Session["admin"]==null)
            {
                return RedirectToAction("Index");
            }
            using (UserContext ctx= new UserContext())
            {
                var lst = ctx.Users.ToList();
                return View(lst);
            }
        }


        public ActionResult Delete(int? id)
        {
            using (UserContext ctx = new UserContext())
            { 
                ctx.Users.Remove(ctx.Users.Find(id));   
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
        }
    }
}