using HealthHub.Data;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> GetRecipesAsync(int patientId)
        {
            return await _unitOfWork.RecipeRepository.GetRecipesAsync(patientId);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _unitOfWork.RecipeRepository.AddAsync(recipe);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
