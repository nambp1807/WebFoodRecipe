using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFoodRecipe.Models;

namespace WebFoodRecipe.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int ? page, string searchModel)
        {
            int pageNumber = (page ?? 1);
            if (searchModel != "" || searchModel != null )
            {
                FoodRecipeDAO dao = new FoodRecipeDAO();
                var res = dao.SearchFoodRecipe(searchModel);
                if(res == null)
                {
                    ViewBag.searchString = searchModel;
                    ViewBag.SearchMess = "No result";
                    return RedirectToAction("Index", "Home");
                }
                return View(res.ToPagedList(pageNumber, 4));
            }
            else
            {
                
                return RedirectToAction("Index", "Home");
            }
        }
    }
}