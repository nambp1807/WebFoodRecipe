using Models.DAO;
using Models.EF;
using Models.SessionCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFoodRecipe.Controllers
{
    public class ContactController : Controller
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
        // GET: Contact
        public ActionResult Index()
        {
            contact_feedback contact_ = new contact_feedback();
            if (!CheckLogin())
            {
                AccountDAO dao = new AccountDAO();
                account ac = dao.GetAccountByEmail(SessionHelper.getUserSession());
                ViewBag.login = SessionHelper.getUserSession();
                contact_.email = ac.email;
                contact_.name = ac.name;
            }
            return View(contact_);
        }
        // POST: Contact -- Create contact
        [HttpPost]
        public ActionResult Index(contact_feedback collection)
        {
            try
            {
                ContactFeedBackDAO dao = new ContactFeedBackDAO();
                if (CheckLogin()) // dang nhap roi thi se khong lay thong tin cua ng ta nua
                {
                    AccountDAO adao = new AccountDAO();
                    account ac = adao.GetAccountByEmail(SessionHelper.getUserSession());
                    ViewBag.login = SessionHelper.getUserSession();
                }
                else
                {
                    contact_feedback contact_ = collection;
                    if (dao.AddNewContactFeedBack(contact_))
                    {
                        ViewBag.Contact = "Thanks for your feedback !";
                        return RedirectToAction("Index", "Contact");
                    }
                    
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }


    }
}
