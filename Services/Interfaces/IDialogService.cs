using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IDialogService
    {
        void ShowError(string message, string title);
        void ShowInformation(string message, string title);
    }
}
