using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AccountDAO
    {
        private food_recipeEntities db = new food_recipeEntities();

        // GET all account in database
        public List<account> GetAllAccount()
        {
            List<account> list = db.account.ToList();
            return list;
        }
        
        // GET account by id
        public account GetAccountById(int ? id)
        {
            account ac = db.account.Find(id);
            return ac;
        }

        // get account by email
        public account GetAccountByEmail(string email)
        {
            account ac = db.account.Include("account_role").Where(a => a.email.Equals(email)).FirstOrDefault();
            return ac;
        }

        // Add new acoount

        public bool AddNewAccount( account account)
        {
            try
            {
                db.account.Add(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Edit account 
        public bool EditAccount(account account)
        {
            try
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Remove account 
        public bool RemoveAccount(account account)
        {
            try
            {
                db.account.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // end crud

         // Check login 
        public bool Login(string email, string password)
        {
            var res = db.account.SingleOrDefault(a => a.email.Equals(email) && a.password.Equals(password));
            if(res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // get role
    }
}
