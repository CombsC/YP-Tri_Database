using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class EventsController : Controller
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
            return View(_db.Events.ToList());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> q = _db.Members.ToList().Select(i => new SelectListItem
            {
                Text = i.First_Name + " " + i.Last_Name,
                Value = i.Member_id.ToString()
            });
            ViewData["Member_Number"] = q;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create(Event e)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Events.Add(e);
                    _db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    IEnumerable<SelectListItem> q = _db.Members.ToList().Select(i => new SelectListItem
                    {
                        Text = i.First_Name + " " + i.Last_Name,
                        Value = i.Member_id.ToString()
                    });
                    ViewData["Member_Number"] = q;
                    return View(e);
                }
                  
            }
            else {
                    IEnumerable<SelectListItem> q = _db.Members.ToList().Select(i => new SelectListItem
                    {
                        Text = i.First_Name + " " + i.Last_Name,
                        Value = i.Member_id.ToString()
                    });
                    ViewData["Member_Number"] = q;
                    return View(e);
                }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Edit(int id)
        {
            Event e = _db.Events.Find(id);
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
        public ActionResult Edit(Event e)
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
            Event e = _db.Events.Find(id);
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
            Event e= _db.Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }


        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event e = _db.Events.Find(id);
            _db.Events.Remove(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed



    }//end EventController
}//end Namespace