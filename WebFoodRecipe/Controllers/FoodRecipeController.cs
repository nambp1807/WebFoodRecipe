using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Controllers
{
    public class FoodRecipeController : Controller
    {
        private FoodRecipeDAO dao = new FoodRecipeDAO();
        // GET: FoodRecipe
        /*public ActionResult Index(int ? page)
        {
            int pageNumber = (page ?? 1);
            var res = dao.GetAllFoodRecipes();
            return View(res.ToPagedList(pageNumber, 4));
        }*/
        // index with type
        public ActionResult Index(int ? id_type, int ? page)
        {
            int pageNumber = (page ?? 1);
            
            if ( id_type == null )
            {
                var res = dao.GetAllFoodRecipes();
                return View(res.ToPagedList(pageNumber, 4));
            }
            else
            {
               
                int type = (id_type ?? 1);
                var res = dao.GetFoodRecipeByType(type);
                ViewBag.Type = type;
                return View(res.ToPagedList(pageNumber, 4));
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            food_recipe food_recipe = dao.GetFoodRecipeByID(id);
            if (food_recipe == null)
            {
                return HttpNotFound();
            }
            FoodRecipeDetailsDAO fdao = new FoodRecipeDetailsDAO();
            ViewBag.FoodRecipeDetail = fdao.GetAllFoodRecipeDetails((int)id);

            return View(food_recipe);
        }
        // index with search
        public ActionResult Search(string search)
        {
            
            return View();
        }

    }
}