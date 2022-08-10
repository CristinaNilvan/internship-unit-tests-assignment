using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.SuggestRecipesFeature.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.CommandHandlers
{
    public class SuggestRecipesHandler : IRequestHandler<SuggestRecipes, List<Recipe>>
    {
        private readonly IRecipeRepository _repository;

        public SuggestRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipe>> Handle(SuggestRecipes request, CancellationToken cancellationToken)
        {
            var recipes = _repository.GetRecipesByApprovedStatus(true).Result;
            var allPossibilities = RecipesSuggesterUtils.FilterByIngredientAndQuantity(request.IngredientName, 
                request.Quantity, recipes);
            var bestMatches = RecipesSuggesterUtils.FilterByBestMatch(request.IngredientName, request.Quantity, 
                allPossibilities);

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
