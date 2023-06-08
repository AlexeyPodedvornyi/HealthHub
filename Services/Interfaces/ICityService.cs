using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface ICityService
    {
        Task<string> ConvertIdToNameAsync(int id);
        string ConvertIdToName(int id);
    }
}
