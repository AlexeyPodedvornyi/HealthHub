using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface ISearchService<T>
    {
        Task<List<T>> SearchAsync(string searchRequest);
    }
}
