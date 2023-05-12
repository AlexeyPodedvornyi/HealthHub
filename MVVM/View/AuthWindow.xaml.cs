using HealthHub.MVVM.Model;
using HealthHub.MVVM.ViewModel;
using HealthHub.Services;
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

namespace HealthHub.MVVM.View
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        IUserService _userService;
        public AuthWindow(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var dbService = new User();
            var user = _userService.GetUser(tb1.Text);
            if(user is Doctor doc) MessageBox.Show($"{doc?.Login}\n {doc?.Password}\n{doc?.Role}");
            else MessageBox.Show($"{user?.Login}\n {user?.Password}");
        }
    }
}
