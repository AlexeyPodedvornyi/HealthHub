using HealthHub.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels.Controls
{
    public class AnimatedSidebarViewModel : ViewModel
    {
        private bool _isSidebarExpanded;

        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set
            {
                if (_isSidebarExpanded != value)
                {
                    _isSidebarExpanded = value;
                    OnPropertyChanged(nameof(IsSidebarExpanded));
                }
            }
        }

        public ICommand SidebarMouseEnterCommand { get; }
        public ICommand SidebarMouseLeaveCommand { get; }


        public AnimatedSidebarViewModel()
        {
            SidebarMouseEnterCommand = new RelayCommand(execute => OnSidebarMouseEnter());
            SidebarMouseLeaveCommand = new RelayCommand(execute => OnSidebarMouseLeave());
        }

        private void OnSidebarMouseEnter()
        {
            IsSidebarExpanded = true;
        }

        private void OnSidebarMouseLeave()
        {
            IsSidebarExpanded = false;
        }
    }
}
