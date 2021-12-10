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
    /// Interaction logic for NotiBuyLand.xaml
    /// </summary>
    public partial class NotiBuyLand : UserControl
    {


        public string NameOfLand
        {
            get { return (string)GetValue(NameOfLandProperty); }
            set { SetValue(NameOfLandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOfLand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOfLandProperty =
            DependencyProperty.Register("NameOfLand", typeof(string), typeof(NotiBuyLand), new PropertyMetadata(""));



        public NotiBuyLand()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public NotiBuyLand(string nameOfLand)
        {
            this.DataContext = this;
            InitializeComponent();
            NameOfLand = nameOfLand;
        }
    }
}
