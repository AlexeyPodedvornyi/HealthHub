using HealthHub.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;
using System.Windows.Xps.Serialization;
using HealthHub.Data;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.Services.Interfaces;

namespace HealthHub.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> IsAccessGrantedAsync(string login, string password)
        {
            IUserAuthInfo? userAuthInfo = await _unitOfWork.DocAuthInfoRepository.SelectAuthInfoAsync(login, password);
            userAuthInfo ??=  await _unitOfWork.AdminAuthInfoRepository.SelectAuthInfoAsync(login, password);

            return userAuthInfo != null;
        }
    }
}
