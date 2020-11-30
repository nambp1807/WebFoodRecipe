using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Controllers
{
    public class FaqsController : Controller
    {
        // check session 
        
        // GET: Faqs
        public ActionResult Index()
        {
            FaqDAO dao = new FaqDAO();
            return View(dao.GetAllFaq());
        }
    }
}
