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
    public class AdminAccountRoleController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminAccountRole
        public ActionResult Index()
        {
            return View(db.account_role.ToList());
        }

        // GET: Admin/AdminAccountRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_role account_role = db.account_role.Find(id);
            if (account_role == null)
            {
                return HttpNotFound();
            }
            return View(account_role);
        }

        // GET: Admin/AdminAccountRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminAccountRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type")] account_role account_role)
        {
            if (ModelState.IsValid)
            {
                db.account_role.Add(account_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account_role);
        }

        // GET: Admin/AdminAccountRole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_role account_role = db.account_role.Find(id);
            if (account_role == null)
            {
                return HttpNotFound();
            }
            return View(account_role);
        }

        // POST: Admin/AdminAccountRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type")] account_role account_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account_role);
        }

        // GET: Admin/AdminAccountRole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_role account_role = db.account_role.Find(id);
            if (account_role == null)
            {
                return HttpNotFound();
            }
            return View(account_role);
        }

        // POST: Admin/AdminAccountRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account_role account_role = db.account_role.Find(id);
            db.account_role.Remove(account_role);
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
