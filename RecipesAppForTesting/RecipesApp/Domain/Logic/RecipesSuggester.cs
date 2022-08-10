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
            var recipes = _repository.GetRecipesByApprovedStatus(true).Result;
            var allPossibilities = RecipesSuggesterUtils.FilterByIngredientAndQuantity(ingredientName, quantity, recipes);
            var bestMatches = RecipesSuggesterUtils.FilterByBestMatch(ingredientName, quantity, recipes);

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }
            else
            {
                return allPossibilities;
            }
        }
    }
}
