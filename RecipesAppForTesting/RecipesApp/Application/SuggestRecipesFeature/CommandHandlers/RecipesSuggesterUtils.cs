using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.CommandHandlers
{
    public class RecipesSuggesterUtils
    {
        public static List<Recipe> FilterByIngredientAndQuantity(string ingredientName, float ingredientQuantity, 
            List<Recipe> recipes)
        {
            var filteredRecipes = new List<Recipe>();
            
            foreach (var recipe in recipes)
            {
                var found = false;

                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.Name == ingredientName && ingredient.Quantity <= ingredientQuantity)
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public static List<Recipe> FilterByBestMatch(string ingredientName, float ingredientQuantity, List<Recipe> recipes)
        {
            var filteredRecipes = new List<Recipe>();

            foreach (var recipe in recipes)
            {
                var found = false;

                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.Name == ingredientName && ingredient.Quantity >= ingredientQuantity / 2)
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }
    }
}
