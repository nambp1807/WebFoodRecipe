using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class RegisterDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // get all register
        public List<register> GetAllRegister()
        {
            List<register> list = db.register.ToList();
            return list;
        }

        // get register by id
        public register GetRegisterByID(int? id)
        {
            register register = db.register.Find(id);
            return register;
        }
        // add new register 
        public bool AddNewRegister(register register)
        {
            try
            {
                db.register.Add(register);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // edit register
        public bool EditRegister(register register)
        {
            try
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // remove register
        public bool RemoveRegister(register register)
        {
            try
            {
                db.register.Remove(register);
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
