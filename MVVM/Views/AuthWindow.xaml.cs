using HealthHub.Data;
using HealthHub.Data.Repositories.AuthInfo;
using HealthHub.Helpers;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.ViewModels;
using HealthHub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthHub.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow( )
        {
            InitializeComponent();
        }
    }
}
