using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.DataContexts;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class MemberController : Controller
    {
        private DataContexts.MembershipDb _db = new DataContexts.MembershipDb();

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize(Roles ="Admin, SuperUser")]
        public ActionResult Index()
        {
            return View(_db.Members.ToList());
        }
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        public ActionResult Create(Member member)
        {
            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("Index", "Member");
        }
    }
}