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
    public class AdminCommentsController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminComments
        public ActionResult Index()
        {
            var comments = db.comment.Include(c => c.account).Include(c => c.food_recipe);
            return View(comments.ToList());
        }

        // GET: Admin/AdminComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/AdminComments/Create
        public ActionResult Create()
        {
            ViewBag.id_account = new SelectList(db.account, "id", "name");
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name");
            return View();
        }

        // POST: Admin/AdminComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_account,id_food_recipe,content,created_at")] comment comment)
        {
            if (ModelState.IsValid)
            {
                db.comment.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_account = new SelectList(db.account, "id", "name", comment.id_account);
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", comment.id_food_recipe);
            return View(comment);
        }

        // GET: Admin/AdminComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_account = new SelectList(db.account, "id", "name", comment.id_account);
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", comment.id_food_recipe);
            return View(comment);
        }

        // POST: Admin/AdminComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_account,id_food_recipe,content,created_at")] comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_account = new SelectList(db.account, "id", "name", comment.id_account);
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", comment.id_food_recipe);
            return View(comment);
        }

        // GET: Admin/AdminComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comment = db.comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/AdminComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comment comment = db.comment.Find(id);
            db.comment.Remove(comment);
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
