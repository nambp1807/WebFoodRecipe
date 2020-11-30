using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CommentDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // Get comment by id
        public comment GetCommentById(int? id)
        {
            comment comment = db.comment.Find(id);
            return comment;
        }

        // get comment by food recipe 
        public List<comment> GetCommentByFoodRecipe(int ? id)
        {
            List<comment> list = new List<comment>();
            list = db.comment.Where(c => c.id_food_recipe == id).ToList();
            return list;
        }

        // Add new comment
        public bool AddNewComment(comment comment)
        {
            try
            {
                db.comment.Add(comment);
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
