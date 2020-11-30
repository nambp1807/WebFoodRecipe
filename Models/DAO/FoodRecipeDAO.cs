using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class FoodRecipeDAO
    {
        // Connection call
        private food_recipeEntities db = new food_recipeEntities();

        // get all food recipe
        public List<food_recipe> GetAllFoodRecipes()
        {
            List<food_recipe> list = db.food_recipe.ToList();
            return list;
        }

        // get food recipe by type
        public List<food_recipe> GetFoodRecipeByType(int id)
        {
            List<food_recipe> list = new List<food_recipe>();
            var res = db.food_recipe.Where(f => f.id_type == id);
            list = res.ToList();
            return list;
        }
        // get food recipe free
        public List<food_recipe> GetFreeFoodRecipes()
        {
            List<food_recipe> list = db.food_recipe.Where(a => a.pay_the_fee == 0).ToList();
            return list;
        }

        // get food of author
        public List<food_recipe> GetFoodByAuthor(int author)
        {
            List<food_recipe> list = new List<food_recipe>();
            var res = db.food_recipe.Where(f => f.author == author);
            list = res.ToList();
            return list;
        }

        // get food new limit 6
        public List<food_recipe> GetFoodNew(int linmit)
        {
            List<food_recipe> list = new List<food_recipe>();

            var res = db.food_recipe.Include("account").OrderBy(a => a.created_at).Take(linmit);
            list = res.ToList();
            return list;
        }
        
        // get food new free limit 2
        public List<food_recipe> GetFoodRecipeNewFree()
        {
            List<food_recipe> list = new List<food_recipe>();
            var res = db.food_recipe.Include("account").OrderBy(a => a.created_at).Take(2);
            list = res.ToList();
            return list;
        }

        // get food new free limit custom

        // get food recipe by id
        public food_recipe GetFoodRecipeByID(int? id)
        {
            food_recipe food = db.food_recipe.Find(id);
            return food;
        }
        // add new food recipe
        public bool AddNewFoodRecipe(food_recipe food_)
        {
            try
            {
                db.food_recipe.Add(food_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // edit food recipe
        public bool EditFoodRecipe(food_recipe food_)
        {
            try
            {
                db.Entry(food_).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // remove food recipe
        public bool RemoveFoodRecipe(food_recipe food_)
        {
            try
            {
                db.food_recipe.Remove(food_);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // end crud 

        public List<food_recipe> SearchFoodRecipe(string Search)
        {
            List<food_recipe> list = new List<food_recipe>();
            var res = db.food_recipe.Where(f => f.name.Contains(Search));
            list = res.ToList();
            return list;
        }
    }
}
