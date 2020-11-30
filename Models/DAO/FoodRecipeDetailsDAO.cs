using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FoodRecipeDetailsDAO
    {
        private food_recipeEntities db = new food_recipeEntities();

        public List<food_recipe_detail> GetAllFoodRecipeDetails()
        {
            List<food_recipe_detail> list = db.food_recipe_detail.ToList();
            return list;
        }
        public List<food_recipe_detail> GetAllFoodRecipeDetails(int id)
        {
            List<food_recipe_detail> list = db.food_recipe_detail.Where(f => f.id_food_recipe == id).ToList();
            return list;
        }

        public food_recipe_detail GetFoodRecipeDetailsById(int? id)
        {
            food_recipe_detail ac = db.food_recipe_detail.Find(id);
            return ac;
        }

       

        public bool AddNewFoodDetailsRecipe(food_recipe_detail food_Recipe_)
        {
            try
            {
                db.food_recipe_detail.Add(food_Recipe_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public bool EditFoodRecipeDetail(food_recipe_detail food_Recipe_)
        {
            try
            {
                db.Entry(food_Recipe_).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Remove account 
        public bool RemoveFoodRecipeDetail(food_recipe_detail food_Recipe_)
        {
            try
            {
                db.food_recipe_detail.Remove(food_Recipe_);
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
