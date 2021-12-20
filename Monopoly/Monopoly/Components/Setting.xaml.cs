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
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
            MusicSlider.Value = Sound.GetBGMVolume() * 100;
            SoundEffectSlider.Value = Sound.GetSEVolume() * 100;
        }

        private void MusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound.SetBGMVolume(MusicSlider.Value / 100);
        }

        private void SoundEffectSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound.SetSEVolume(SoundEffectSlider.Value / 100);
        }

        public static readonly RoutedEvent OkButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnOkButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Setting));

        public event RoutedEventHandler OnOkButtonClick
        {
            add { AddHandler(OkButtonClickEvent, value); }
            remove { RemoveHandler(OkButtonClickEvent, value); }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OkButtonClickEvent));
        }
    }
}
