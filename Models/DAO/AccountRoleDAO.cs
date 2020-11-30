using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AccountRoleDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // Get all role 
        public List<account_role> GetAccount_Roles()
        {
            List<account_role> list = db.account_role.ToList();
            return list;
        }

        // Get role by id
        public account_role GetAccount_RoleById(int ? id)
        {
            account_role account_ = db.account_role.Find(id);
            return account_;
        }

        // Add new Role
        public bool AddNewAccountRole(account_role account_)
        {
            try
            {
                db.account_role.Add(account_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Edit account role
        public bool EditAccountRole(account_role account_)
        {
            try
            {
                db.Entry(account_).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Remove account role
        public bool RemoveAccountRole(account_role account_)
        {
            try
            {
                db.account_role.Remove(account_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // end crud
    }
}
