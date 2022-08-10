using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.Commands
{
    public class SuggestRecipes : IRequest<List<Recipe>>
    {
        public string IngredientName { get; set; }
        public float Quantity { get; set; }
    }
}