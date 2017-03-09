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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="User, Admin, SuperUser")]
        public ActionResult Index()
        {
            return View(_db.Events.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailsEvent(int id)
        {            
            Event e = _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        
         }

 
    }
}