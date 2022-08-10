using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IIngredientRepository
    {
        Task CreateIngredient(Ingredient ingredient);
        Task<Ingredient> GetIngredientById(int ingredientId);
        Task<Ingredient> GetIngredientByName(string ingredientName);
        Task UpdateIngredient(int ingredientId, Ingredient newIngredient);
        Task UpdateIngredientStatus(int ingredientId, bool status);
        Task DeleteIngredient(int ingredientId);
        Task<List<Ingredient>> GetAllIngredients();
        Task<List<Ingredient>> GetIngredientsByApprovedStatus(bool isApproved);
    }
}
