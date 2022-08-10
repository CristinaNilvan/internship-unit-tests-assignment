using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IRecipeRepository
    {
        Task CreateRecipe(Recipe recipe);
        Task<Recipe> GetRecipeById(int recipeId);
        Task<Recipe> GetRecipeByName(string recipeName);
        Task UpdateRecipe(int recipeId, Recipe newRecipe);
        Task UpdateRecipeStatus(int recipeId, bool status);
        Task DeleteRecipe(int recipeId);
        Task<List<Recipe>> GetAllRecipes();
        Task<List<Recipe>> GetRecipesByApprovedStatus(bool isApproved);
        Task<List<Recipe>> GetRecipesByIngredients(List<Ingredient> ingredients);
    }
}