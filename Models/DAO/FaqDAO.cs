using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FaqDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // get all faqs
        public List<faq> GetAllFaq()
        {
            List<faq> list = db.faq.ToList();
            return list;
        }

        // get faq by id
        public faq GetFaqByID(int? id)
        {
            faq faq = db.faq.Find(id);
            return faq;
        }
        // add new faq 
        public bool AddNewFaq(faq faq)
        {
            try
            {
                db.faq.Add(faq);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // edit exam
        public bool EditFaq(faq faq)
        {
            try
            {
                db.Entry(faq).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // remove exam
        public bool RemoveFaq(faq faq)
        {
            try
            {
                db.faq.Remove(faq);
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
