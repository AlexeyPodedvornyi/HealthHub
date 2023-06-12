﻿using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesAsync(int patientId);
        Task AddRecipeAsync(Recipe recipe);
    }
}
