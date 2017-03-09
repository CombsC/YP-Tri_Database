using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.DataContexts;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class UserController : Controller
    {
        private MembershipDb _db = new MembershipDb();

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_db.Events.ToList());
        }

        public ActionResult DetailsEvent(int id)
        {            
            Event e = _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        
         }

        public ActionResult Register()
        {
             return View();
        }

        [HttpPost]
        public ActionResult Register(Member m)
        {
           
            if(ModelState.IsValid)
            {
                
                _db.Members.Add(m);
                _db.SaveChanges();
                return RedirectToAction("About", "Home");
            }
            return View(m);
        }
    }
}