using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class SponsorsController : Controller
    {
        private DataContexts.MembershipDb _db = new DataContexts.MembershipDb();

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Index()
        {
            return View(_db.Sponsors.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create(Sponsor e)
        {
            if (ModelState.IsValid)
            {
                _db.Sponsors.Add(e);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(int id)
        {
            Sponsor e = _db.Sponsors.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(Sponsor e)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Details(int id)
        {
            Sponsor e = _db.Sponsors.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Delete(int id)
        {
            Sponsor e = _db.Sponsors.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }


        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsor s = _db.Sponsors.Find(id);
            _db.Sponsors.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed
    }
}