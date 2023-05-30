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
    /// Interaction logic for ImageRadioButton.xaml
    /// </summary>
    public partial class ImageRadioButton : RadioButton
    {
        static ImageRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageRadioButton), new FrameworkPropertyMetadata(typeof(ImageRadioButton)));
        }

       public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageRadioButton));

        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(object), typeof(ImageRadioButton));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }   

        public object LabelContent
        {
            get { return GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
    }
}
