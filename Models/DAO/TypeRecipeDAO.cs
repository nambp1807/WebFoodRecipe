using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class TypeRecipeDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // get all type recipe
        public List<type_recipe> GetAllTypeRecipe()
        {
            List<type_recipe> list = db.type_recipe.ToList();
            return list;
        }

        // get type recipe by id
        public type_recipe GetTypeRecipeByID(int? id)
        {
            type_recipe type_ = db.type_recipe.Find(id);
            return type_;
        }
        // add new type recipe
        public bool AddNewTypeRecipe(type_recipe type_)
        {
            try
            {
                db.type_recipe.Add(type_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // edit type recipe
        public bool EditTypeRecipe(type_recipe type_)
        {
            try
            {
                db.Entry(type_).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // remove type recipe
        public bool RemoveTypeRecipe(type_recipe type_)
        {
            try
            {
                db.type_recipe.Remove(type_);
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
