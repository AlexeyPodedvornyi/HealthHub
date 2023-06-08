using HealthHub.Data;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<string> ConvertIdToNameAsync(int id)
        {
            return await _unitOfWork.CityRepository.GetCityNameByIdAsync(id);
        }

        public string ConvertIdToName(int id)
        {
            return _unitOfWork.CityRepository.GetCityNameById(id);
        }
    }
}
