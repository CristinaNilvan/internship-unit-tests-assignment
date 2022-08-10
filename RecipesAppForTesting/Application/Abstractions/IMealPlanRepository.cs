using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Abstractions
{
    public interface IMealPlanRepository
    {
        Task CreateMealPlan(MealPlan mealPlan);
        Task<MealPlan> GetMealPlanById(int mealPlanId);
        Task UpdateMealPlan(int mealPlanId, MealPlan newMealPlan);
        Task DeleteMealPlan(int mealPlanId);
        Task<List<MealPlan>> GetAllMealPlans();
    }
}
