using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace WebFoodRecipe.Areas.Admin.Controllers
{
    public class AdminContactFeedbackController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminContactFeedback
        public ActionResult Index()
        {
            return View(db.contact_feedback.ToList());
        }

        // GET: Admin/AdminContactFeedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_feedback contact_feedback = db.contact_feedback.Find(id);
            if (contact_feedback == null)
            {
                return HttpNotFound();
            }
            return View(contact_feedback);
        }

        // GET: Admin/AdminContactFeedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminContactFeedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,content")] contact_feedback contact_feedback)
        {
            if (ModelState.IsValid)
            {
                db.contact_feedback.Add(contact_feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact_feedback);
        }

        // GET: Admin/AdminContactFeedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_feedback contact_feedback = db.contact_feedback.Find(id);
            if (contact_feedback == null)
            {
                return HttpNotFound();
            }
            return View(contact_feedback);
        }

        // POST: Admin/AdminContactFeedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,content")] contact_feedback contact_feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact_feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact_feedback);
        }

        // GET: Admin/AdminContactFeedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact_feedback contact_feedback = db.contact_feedback.Find(id);
            if (contact_feedback == null)
            {
                return HttpNotFound();
            }
            return View(contact_feedback);
        }

        // POST: Admin/AdminContactFeedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contact_feedback contact_feedback = db.contact_feedback.Find(id);
            db.contact_feedback.Remove(contact_feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
