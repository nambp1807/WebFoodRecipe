using Models.DAO;
using Models.EF;
using Models.SessionCommon;
using PagedList;
using System.Net;
using System.Web.Mvc;
using WebFoodRecipe.Models;

namespace WebFoodRecipe.Controllers
{
    public class ExamsController : Controller
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
        // call dao 
        private ExamDAO dao = new ExamDAO();
        // GET: Exams
        public ActionResult Index(int? page)
        {
            // check Login
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            var res = dao.GetAllExam();
            return View(res.ToPagedList(pageNumber,pageSize));
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            // check login 
           
            // khong co id truyen vao thi tra ve loi
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            exam exam = dao.GetExamByID(id);
            ViewBag.examid = id;
            // khong co id phu hop tra ve loi
            if(exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult register()
        {
            ExamRegister ex = new ExamRegister();
            if(!CheckLogin())
            {
                AccountDAO dao = new AccountDAO();
                account ac = dao.GetAccountByEmail(SessionHelper.getUserSession());
                ViewBag.login = SessionHelper.getUserSession();
                ex.email = ac.email;
                ex.name = ac.name;
            }
            return View(ex);
        }
        // http post 
        [HttpPost]
        public ActionResult register(ExamRegister register)
        {
            if (register !=null )
            {
                register re = new register();
                re.name = register.name;
                re.email = register.email;
                re.content = register.content;
                re.exam = register.idExam;
                RegisterDAO dao = new RegisterDAO();
                if (dao.AddNewRegister(re)){

                }
                else
                {
                    ViewBag.registermess = "Error register ! Please register again.";
                }
            }
            return View(register);
        }
    }
}
