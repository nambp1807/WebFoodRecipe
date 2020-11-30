using System.Net;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;
using Models.SessionCommon;
using PagedList;
using WebFoodRecipe.Models;

namespace WebFoodRecipe.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Default)]
    public class AccountsController : Controller
    {
        // check session 


        private AccountDAO dao = new AccountDAO();

        // 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLogin account)
        {
            if (dao.Login(account.Email, account.Password))
            {
                account ac = dao.GetAccountByEmail(account.Email);
                UserSession user = new UserSession();
                user.UsernameSession = ac.email;
                user.RoleSession = ac.account_role.type;
                SessionHelper.setSession(user);
                if(ac.id_role == 1 || user.RoleSession.Equals("admin"))
                {
                    return RedirectToAction("Index", "Admin/AdminFoodRecipe");

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                    
                }
            }
            else
            {
                ViewBag.Message = "Loi dang nhap !";
                return RedirectToAction("Login", "Accounts");
            }
        }

        // logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        // Register
        public ActionResult register()
        {
            ViewBag.Message = "Wellcome ~!";
            return View();
        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult register(AccountRegister account)
        {
            if (account.Password == account.Confirm_password)
            {
                account ac = new account();
                ac.id_role = 2;
                ac.name = account.Name;
                ac.email = account.Email;
                ac.password = account.Password;
                ac.image = "/Images/img/bg-img/23.jpg"; // set mac dinh img luc dang ky sau nay edit sau
                if (dao.GetAccountByEmail(account.Email) == null)
                {
                    if (dao.AddNewAccount(ac))
                    {
                        ViewBag.Message = "Success register. Please login with your new account !";
                        return RedirectToAction("Login", "Accounts");
                    }
                    else
                    {
                        ViewBag.Message = "Eror register ! Please check your information again.";
                    }
                }
                else
                {
                    ViewBag.Message = "Email is exits ! Please check your email again.";
                    return View(account);
                }

            }
            else
            {
                ViewBag.Message = "Confirm password don't match ! Please confirm password !";
            }
            return View(account);
        }

        // GET: Accounts/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = dao.GetAccountById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            AccountRoleDAO db = new AccountRoleDAO();
            ViewBag.id_role = new SelectList(db.GetAccount_Roles(), "id", "type", account.id_role);
            return View(account);
        }

        // POST: Accounts/Edit/
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,id_role,image,phone,password")] account account)
        {
            if (ModelState.IsValid)
            {
                dao.EditAccount(account);
                return RedirectToAction("Index");
            }
            AccountRoleDAO db = new AccountRoleDAO();
            ViewBag.id_role = new SelectList(db.GetAccount_Roles(), "id", "type", account.id_role);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = dao.GetAccountById(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account account = dao.GetAccountById(id);
            dao.RemoveAccount(account);
            // tra ve trang chu
            return RedirectToAction("Index");
        }

    }
}
