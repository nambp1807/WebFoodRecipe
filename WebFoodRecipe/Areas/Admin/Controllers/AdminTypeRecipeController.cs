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
    public class AdminTypeRecipeController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminTypeRecipe
        public ActionResult Index()
        {
            return View(db.type_recipe.ToList());
        }

        // GET: Admin/AdminTypeRecipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_recipe type_recipe = db.type_recipe.Find(id);
            if (type_recipe == null)
            {
                return HttpNotFound();
            }
            return View(type_recipe);
        }

        // GET: Admin/AdminTypeRecipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTypeRecipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,image")] type_recipe type_recipe)
        {
            if (ModelState.IsValid)
            {
                db.type_recipe.Add(type_recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_recipe);
        }

        // GET: Admin/AdminTypeRecipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_recipe type_recipe = db.type_recipe.Find(id);
            if (type_recipe == null)
            {
                return HttpNotFound();
            }
            return View(type_recipe);
        }

        // POST: Admin/AdminTypeRecipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,image")] type_recipe type_recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_recipe);
        }

        // GET: Admin/AdminTypeRecipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type_recipe type_recipe = db.type_recipe.Find(id);
            if (type_recipe == null)
            {
                return HttpNotFound();
            }
            return View(type_recipe);
        }

        // POST: Admin/AdminTypeRecipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            type_recipe type_recipe = db.type_recipe.Find(id);
            db.type_recipe.Remove(type_recipe);
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
