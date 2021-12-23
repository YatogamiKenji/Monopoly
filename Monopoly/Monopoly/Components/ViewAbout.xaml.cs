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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ViewAbout.xaml
    /// </summary>
    public partial class ViewAbout : UserControl
    {
        public ViewAbout()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBackButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));
        public event RoutedEventHandler OnBackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }
        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(BackButtonClickEvent));
        }
    }
}
