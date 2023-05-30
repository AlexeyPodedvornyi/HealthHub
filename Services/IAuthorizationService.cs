using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public interface IAuthorizationService
    {
        Task<bool> IsAccessGrantedAsync(string login, string password);
    }
}
