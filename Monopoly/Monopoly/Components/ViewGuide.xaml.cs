using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ViewGuide.xaml
    /// </summary>
    public partial class ViewGuide : UserControl
    {
        public int CurPic;
        public ViewGuide()
        {
            InitializeComponent();
            CurPic = 1;
        }
        public static readonly RoutedEvent BackButtonClickEvent =
           EventManager.RegisterRoutedEvent(nameof(OnBackButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));
        public event RoutedEventHandler OnBackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(BackButtonClickEvent));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            CurPic++;
            if (CurPic == 6)
            {
                Next.Visibility = Visibility.Collapsed;
            }
            else
            {
                Prev.Visibility = Visibility.Visible;
                Next.Visibility = Visibility.Visible;
            }
            GuidePic.Source = new BitmapImage(new Uri(@"/Images/Guide/" + CurPic + ".png", UriKind.Relative));
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            CurPic--;
            if (CurPic == 1)
            {
                Prev.Visibility = Visibility.Collapsed;
            }
            else
            {
                Next.Visibility = Visibility.Visible;
                Prev.Visibility = Visibility.Visible;
            }
            GuidePic.Source = new BitmapImage(new Uri(@"/Images/Guide/" + CurPic + ".png", UriKind.Relative));
        }
    }
}
