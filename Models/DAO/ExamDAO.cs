using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ExamDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // get all exams
        public List<exam> GetAllExam()
        {
            List<exam> list = db.exam.ToList();
            return list;
        }

        // get exam by id
        public exam GetExamByID(int? id)
        {
            exam ex = db.exam.Find(id);
            return ex;
        }
        // add new exam 
        public bool AddNewExam(exam exam)
        {
            try
            {
                db.exam.Add(exam);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // edit exam
        public bool EditExam(exam exam)
        {
            try
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // remove exam
        public bool RemoveExam(exam exam)
        {
            try
            {
                db.exam.Remove(exam);
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
