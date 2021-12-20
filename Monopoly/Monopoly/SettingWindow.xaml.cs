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
using System.Windows.Shapes;
using Monopoly.Components;

namespace Monopoly
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();         
            MusicSlider.Value = Sound.GetBGMVolume()*100;
            SoundEffectSlider.Value = Sound.GetSEVolume()*100;
        }

        private void MusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound.SetBGMVolume(MusicSlider.Value / 100);
        }

        private void SoundEffectSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sound.SetSEVolume(SoundEffectSlider.Value / 100);
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
