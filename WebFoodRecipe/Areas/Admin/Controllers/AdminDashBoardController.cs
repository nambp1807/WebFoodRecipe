using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Areas.Admin.Controllers
{
    public class AdminDashBoardController : Controller
    {
        // GET: Admin/AdminDashBoard
        public ActionResult Index()
        {
            AccountDAO dao = new AccountDAO();
            ViewBag.Account = dao.GetAllAccount();
            ViewBag.AccountNumber = dao.GetAllAccount().Count();

            FoodRecipeDAO fdao = new FoodRecipeDAO();
            ViewBag.FoodRecipeNumber = fdao.GetAllFoodRecipes().Count();

            FaqDAO fao = new FaqDAO();
            ViewBag.FaqNumber = fao.GetAllFaq().Count();
            return View();
        }

        // GET: Admin/AdminDashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminDashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDashBoard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminDashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminDashBoard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminDashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminDashBoard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
