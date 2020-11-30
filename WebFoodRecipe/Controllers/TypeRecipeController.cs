using Models.DAO;
using Models.SessionCommon;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Controllers
{
    public class TypeRecipeController : Controller
    {
        // check login
        private bool CheckLogin()
        {
            string user = SessionHelper.getUserSession();
            return (user == null || user.Equals(""));
        }
        // check role 
        private bool roleAdmin()
        {
            string role = SessionHelper.getRoleSession();
            return (role == "admin");
        }
        // GET: TypeRecipe
        public ActionResult Index(int ? page)
        {
            int pageNumber = (page ?? 1);
            TypeRecipeDAO dao = new TypeRecipeDAO();
            var res = dao.GetAllTypeRecipe();
            return View(res.ToPagedList(pageNumber, 6));
        }

        // GET: TypeRecipe/Details/5
    }
}
