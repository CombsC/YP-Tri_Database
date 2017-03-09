using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YPTriMembership.DataContexts;
using YPTriMembership.Models;

namespace YPTriMembership.Controllers
{
    public class AdminController : Controller
    {
        private DataContexts.MembershipDb _db = new DataContexts.MembershipDb();

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
        /// <summary>
        /// Home Page for "Admin Portal" Allows access to all admin level functions. Search functionality has been added through a partial view.
        /// </summary>
        /// <returns> List of Members to the View</returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Index(string searchTerm = null)
        {
            var q = _db.Members.Where(n => searchTerm == null || n.Last_Name.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);

            /* if(option == "First_Name")
             {
                 q = _db.Members.Where(n => n.First_Name.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);
             }
             if(option == "State")
             {
                 q = _db.Members.Where(n => n.State_Abr.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);
             }
             if (option == "Email")
             {
                 q = _db.Members.Where(n => n.Email.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);
             }
             if (option == "Gender")
             {
                 q = _db.Members.Where(n => n.gender.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);
             }
             if (option == "Occupation")
             {
                 q = _db.Members.Where(n => n.Occupation.StartsWith(searchTerm)).OrderBy(n => n.Last_Name);
             }*/

            if (Request.IsAjaxRequest())
            {
                return PartialView("_MemberList", q.ToList());
            }
            return View(q.ToList());
            //return View(_db.Members.ToList());
        }//end Index


        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Applicants()
        {
            return View(_db.Members.ToList());
        }
        /// <summary>
        /// This is an Action Result to perform an Ajax query on the database for autocomplete
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult SearchLabels(string term = null)
        {
            var query = _db.Members
               .Where(c => term == null || c.Last_Name.StartsWith(term))
               .Take(15)
               .Select(c => new
               {
                   label = c.Last_Name
               });
            /*
            if (option == "First_Name")
            {
                query = _db.Members
               .Where(c => term == null || c.First_Name.StartsWith(term))
               .Take(15)
               .Select(c => new {
                   label = c.First_Name
               });
            }
            if (option == "State")
            {
                query = _db.Members
               .Where(c => term == null || c.State_Abr.StartsWith(term))
               .Take(15)
               .Select(c => new {
                   label = c.State_Abr
               });
            }
            if (option == "Email")
            {
                query = _db.Members
               .Where(c => term == null || c.Email.StartsWith(term))
               .Take(15)
               .Select(c => new {
                   label = c.Email
               });
            }
            if (option == "Gender")
            {
                query = _db.Members
               .Where(c => term == null || c.gender.StartsWith(term))
               .Take(15)
               .Select(c => new {
                   label = c.gender
               });
            }
            if (option == "Occupation")
            {
                query = _db.Members
               .Where(c => term == null || c.Occupation.StartsWith(term))
               .Take(15)
               .Select(c => new {
                   label = c.Occupation
               });
            }*/
            return Json(query, JsonRequestBehavior.AllowGet);
        }//end SearchLabels


        /// <summary>
        /// Allows for the creation of members to the database and update of registered members list
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult Create()
        {
            return View();
        }//end Create

        /// <summary>
        /// This actionresult is used to add the post data from the Create method to the database and update the database.
        /// </summary>
        /// <param name="member">Model of Member class</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);  //returns the user to the form if there are errors
            }
            
            _db.Members.Add(member);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }//end Create(HTTP POST)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult EditMember(int id)
        {
            Member member = _db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }//end EditMember

        /// <summary>
        /// HTTP POST actionresult of EditMember
        /// </summary>
        /// <param name="member">a model of the member that has been changed by the user through POST data</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(member).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }// end HTTP POST EditMember

        /// <summary>
        /// An action method for viewing the entire data stored within the entry of a Member Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult MemberDetails(int id)
        {
            Member member = _db.Members.Find(id);
            if(member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        /// <summary>
        /// An action method to delete a member from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        public ActionResult DeleteMember(int id)
        {
           
            Member member = _db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }//end DeleteMember


        /// <summary>
        /// An actionresult to confirm the deletion of the selected member
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = _db.Members.Find(id);
            _db.Members.Remove(member);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }//end DeleteConfirmed

    }//end AdminController
}//end Namespace