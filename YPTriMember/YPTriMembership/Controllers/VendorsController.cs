using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class VendorsController : Controller
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
            return View(_db.Vendors.ToList());
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
        public ActionResult Create(Vendor e)
        {
            if (ModelState.IsValid)
            {
                _db.Vendors.Add(e);
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
            Vendor e = _db.Vendors.Find(id);
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
        public ActionResult Edit(Vendor e)
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
            Vendor e = _db.Vendors.Find(id);
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
            Vendor e = _db.Vendors.Find(id);
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
            Vendor v = _db.Vendors.Find(id);
            _db.Vendors.Remove(v);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed
    }
}