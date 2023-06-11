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
using HealthHub.MVVM.Models.Doctors;

namespace HealthHub.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        public AuthorizationService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<bool> IsAccessGrantedAsync(string login, string password)
        {
            IUserAuthInfo? userAuthInfo = await FindUserAsync(login, password);

            if (userAuthInfo != null)
            {
                SetCurrentUser(userAuthInfo);
                return true;
            }

            return false;
        }

        private async Task<IUserAuthInfo?> FindUserAsync(string login, string password)
        {
            IUserAuthInfo? userAuthInfo = await _unitOfWork.DocAuthInfoRepository.SelectAuthInfoAsync(login, password);
            userAuthInfo ??= await _unitOfWork.AdminAuthInfoRepository.SelectAuthInfoAsync(login, password);

            return userAuthInfo;
        }

        private void SetCurrentUser(IUserAuthInfo userAuthInfo)
        {
            _currentUserService.CurrentUser = userAuthInfo;

            if (userAuthInfo is DocAuthInfo)
            {
                _currentUserService.CurrentRole = "doctor";
            }
            else if (userAuthInfo is AdminAuthInfo)
            {
                _currentUserService.CurrentRole = "admin";
            }
        }
    }
}
