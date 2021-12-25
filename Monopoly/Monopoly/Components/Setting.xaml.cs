using System;
using System.Windows;
using System.Windows.Controls;

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

        public static readonly RoutedEvent CloseButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnCloseButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Setting));

        public event RoutedEventHandler OnCloseButtonClick
        {
            add { AddHandler(CloseButtonClickEvent, value); }
            remove { RemoveHandler(CloseButtonClickEvent, value); }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(CloseButtonClickEvent));
        }

        public static readonly RoutedEvent HomeButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnHomeButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Setting));

        public event RoutedEventHandler OnHomeButtonClick
        {
            add { AddHandler(HomeButtonClickEvent, value); }
            remove { RemoveHandler(HomeButtonClickEvent, value); }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(HomeButtonClickEvent));
        }
    }
}
