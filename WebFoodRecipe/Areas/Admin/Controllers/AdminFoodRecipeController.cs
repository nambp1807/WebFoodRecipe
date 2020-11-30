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
    public class AdminFoodRecipeController : Controller
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET: Admin/AdminFoodRecipe
        public ActionResult Index()
        {
            var food_recipe = db.food_recipe.Include(f => f.account).Include(f => f.type_recipe);
            return View(food_recipe.ToList());
        }

        // GET: Admin/AdminFoodRecipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe food_recipe = db.food_recipe.Find(id);
            if (food_recipe == null)
            {
                return HttpNotFound();
            }
            return View(food_recipe);
        }

        // GET: Admin/AdminFoodRecipe/Create
        public ActionResult Create()
        {
            ViewBag.author = new SelectList(db.account, "id", "name");
            ViewBag.id_type = new SelectList(db.type_recipe, "id", "name");
            return View();
        }

        // POST: Admin/AdminFoodRecipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_type,name,content,pay_the_fee,image,author,created_at")] food_recipe food_recipe)
        {
            if (ModelState.IsValid)
            {
                db.food_recipe.Add(food_recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author = new SelectList(db.account, "id", "name", food_recipe.author);
            ViewBag.id_type = new SelectList(db.type_recipe, "id", "name", food_recipe.id_type);
            return View(food_recipe);
        }

        // GET: Admin/AdminFoodRecipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe food_recipe = db.food_recipe.Find(id);
            if (food_recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.author = new SelectList(db.account, "id", "name", food_recipe.author);
            ViewBag.id_type = new SelectList(db.type_recipe, "id", "name", food_recipe.id_type);
            return View(food_recipe);
        }

        // POST: Admin/AdminFoodRecipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_type,name,content,pay_the_fee,image,author,created_at")] food_recipe food_recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author = new SelectList(db.account, "id", "name", food_recipe.author);
            ViewBag.id_type = new SelectList(db.type_recipe, "id", "name", food_recipe.id_type);
            return View(food_recipe);
        }

        // GET: Admin/AdminFoodRecipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe food_recipe = db.food_recipe.Find(id);
            if (food_recipe == null)
            {
                return HttpNotFound();
            }
            return View(food_recipe);
        }

        // POST: Admin/AdminFoodRecipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            food_recipe food_recipe = db.food_recipe.Find(id);
            db.food_recipe.Remove(food_recipe);
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
