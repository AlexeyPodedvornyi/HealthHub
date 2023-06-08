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

namespace HealthHub.CustomControls
{
    /// <summary>
    /// Interaction logic for AnimatedSidebar.xaml
    /// </summary>
    public partial class AnimatedSidebar : Border
    {
        public AnimatedSidebar()
        {
            InitializeComponent();
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimatedSidebar), new FrameworkPropertyMetadata(typeof(AnimatedSidebar)));
        }

        public static readonly DependencyProperty SidebarContentProperty =
       DependencyProperty.Register("SidebarContent", typeof(object), typeof(AnimatedSidebar), new PropertyMetadata(null));

        public object SidebarContent
        {
            get { return GetValue(SidebarContentProperty); }
            set { SetValue(SidebarContentProperty, value); }
        }
    }
}
