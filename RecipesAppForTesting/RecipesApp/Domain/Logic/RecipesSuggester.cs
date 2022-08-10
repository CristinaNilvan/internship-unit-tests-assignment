using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Domain.Logic
{
    public class RecipesSuggester
    {
        private readonly IRecipeRepository _repository;

        public RecipesSuggester(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public List<Recipe> SuggestRecipes(string ingredientName, float quantity)
        {
            var allRecipes = _repository.GetRecipesByApprovedStatus(true);
            var recipesWithIngredient = RecipesSuggesterUtils.FilterByIngredientAndQuantity(ingredientName, quantity, allRecipes);
            var bestMatches = RecipesSuggesterUtils.FilterByBestMatch(ingredientName, quantity, allRecipes);

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }
            else if (recipesWithIngredient.Count != 0)
            {
                return recipesWithIngredient;
            }
            else
            {
                return allRecipes;
            }
        }
    }
}
