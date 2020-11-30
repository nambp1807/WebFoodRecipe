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
    public class AdminFoodRecipeDetailController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminFoodRecipeDetail
        public ActionResult Index()
        {
            var food_recipe_detail = db.food_recipe_detail.Include(f => f.food_recipe);
            return View(food_recipe_detail.ToList());
        }

        // GET: Admin/AdminFoodRecipeDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe_detail food_recipe_detail = db.food_recipe_detail.Find(id);
            if (food_recipe_detail == null)
            {
                return HttpNotFound();
            }
            return View(food_recipe_detail);
        }

        // GET: Admin/AdminFoodRecipeDetail/Create
        public ActionResult Create()
        {
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name");
            return View();
        }

        // POST: Admin/AdminFoodRecipeDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_food_recipe,step,content")] food_recipe_detail food_recipe_detail)
        {
            if (ModelState.IsValid)
            {
                db.food_recipe_detail.Add(food_recipe_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", food_recipe_detail.id_food_recipe);
            return View(food_recipe_detail);
        }

        // GET: Admin/AdminFoodRecipeDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe_detail food_recipe_detail = db.food_recipe_detail.Find(id);
            if (food_recipe_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", food_recipe_detail.id_food_recipe);
            return View(food_recipe_detail);
        }

        // POST: Admin/AdminFoodRecipeDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_food_recipe,step,content")] food_recipe_detail food_recipe_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_recipe_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_food_recipe = new SelectList(db.food_recipe, "id", "name", food_recipe_detail.id_food_recipe);
            return View(food_recipe_detail);
        }

        // GET: Admin/AdminFoodRecipeDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe_detail food_recipe_detail = db.food_recipe_detail.Find(id);
            if (food_recipe_detail == null)
            {
                return HttpNotFound();
            }
            return View(food_recipe_detail);
        }

        // POST: Admin/AdminFoodRecipeDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            food_recipe_detail food_recipe_detail = db.food_recipe_detail.Find(id);
            db.food_recipe_detail.Remove(food_recipe_detail);
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
