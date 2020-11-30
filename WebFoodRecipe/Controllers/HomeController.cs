using Models.DAO;
using Models.SessionCommon;
using System.Web.Mvc;
using System.Web.SessionState;

namespace WebFoodRecipe.Controllers
{
    // using session
    [SessionState(SessionStateBehavior.Default)]
    public class HomeController : Controller
    {
        // check session 
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
        // GET: Home
        public ActionResult Index()
        {
            ExamDAO dao = new ExamDAO();
            FoodRecipeDAO fdao = new FoodRecipeDAO();

            ViewBag.Exam = dao.GetAllExam();
            if (CheckLogin())
            {
                ViewBag.login = SessionHelper.getRoleSession();
                ViewBag.FoodNew = null;
            }
            else
            {
                ViewBag.login = SessionHelper.getUserSession();
                ViewBag.FoodNew = fdao.GetFoodNew(6);
            }
            ViewBag.FoodNewFree = fdao.GetFoodRecipeNewFree();
            
            return View();
        }
    }
}
