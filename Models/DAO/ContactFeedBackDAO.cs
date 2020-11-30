using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ContactFeedBackDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // Get all contact feedback
        public List<contact_feedback> GetContactFeedBack()
        {
            List<contact_feedback> list = db.contact_feedback.ToList();
            return list;
        }

        // Get contact feedback by id
        public contact_feedback GetContactFeedBackById(int? id)
        {
            contact_feedback contact_ = db.contact_feedback.Find(id);
            return contact_;
        }

        // Add new contact feed back
        public bool AddNewContactFeedBack(contact_feedback contact_)
        {
            try
            {
                db.contact_feedback.Add(contact_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
