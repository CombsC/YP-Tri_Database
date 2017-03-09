using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class HobbiesController : Controller
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
            return View(_db.Hobbies.ToList());
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
        /// <param name="h"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create(Hobby h)
        {
            if (ModelState.IsValid)
            {
                _db.Hobbies.Add(h);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(int id)
        {
            Hobby h = _db.Hobbies.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(Hobby h)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(h).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Delete(int id)
        {
            Hobby h = _db.Hobbies.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }


        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Hobby h)
        {
            var hobbyId = _db.Hobbies.Where(i => i.HobbyId.Equals(h.HobbyId)).FirstOrDefault();
            _db.Hobbies.Remove(hobbyId);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed
    }
}