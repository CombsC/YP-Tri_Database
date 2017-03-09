using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
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
            return View(_db.Skills.ToList());
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
        public ActionResult Create(Skill s)
        {
            if (ModelState.IsValid)
            {
                _db.Skills.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(int id)
        {
            Skill s = _db.Skills.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(Skill s)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Delete(int id)
        {
            Skill s = _db.Skills.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }


        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill s = _db.Skills.Find(id);
            _db.Skills.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed
    }
}