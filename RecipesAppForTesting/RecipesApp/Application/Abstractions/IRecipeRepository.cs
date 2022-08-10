using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipesByApprovedStatus(bool isApproved);
    }
}