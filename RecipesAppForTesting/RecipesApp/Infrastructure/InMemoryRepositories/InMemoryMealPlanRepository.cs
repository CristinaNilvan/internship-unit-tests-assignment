using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Infrastructure.InMemoryRepositories
{
    public class InMemoryMealPlanRepository : IMealPlanRepository
    {
        private List<MealPlan> _mealPlans = new();

        public async Task CreateMealPlan(MealPlan mealPlan)
        {
            mealPlan.Id = _mealPlans.Count > 0 ? _mealPlans.ElementAt(_mealPlans.Count - 1).Id + 1 : 1;
            _mealPlans.Add(mealPlan);
        }

        public async Task DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            _mealPlans.Remove(mealPlan);
        }

        public async Task<MealPlan> GetMealPlanById(int mealPlanId)
        {
            return _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
        }

        public async Task<List<MealPlan>> GetAllMealPlans()
        {
            return _mealPlans;
        }

        public async Task UpdateMealPlan(int mealPlanId, MealPlan newMealPlan)
        {
            var mealPlan = _mealPlans.FirstOrDefault(x => x.Id == mealPlanId);
            var index = _mealPlans.IndexOf(mealPlan);
            mealPlan.Id = mealPlanId;
            _mealPlans[index] = newMealPlan;
        }
    }
}
