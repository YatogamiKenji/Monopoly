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
using Monopoly.Components;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.IO;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ViewStart.xaml
    /// </summary>
    public partial class ViewStart : UserControl
    {
        MediaPlayer mp = new MediaPlayer();

        public ViewStart()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent QuitButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnQuitButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));

        public event RoutedEventHandler OnQuitButtonClick
        {
            add { AddHandler(QuitButtonClickEvent, value); }
            remove { RemoveHandler(QuitButtonClickEvent, value); }
        }

        private void QUIT_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(QuitButtonClickEvent));
        }

        public static readonly RoutedEvent PlayButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnPlayButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));

        public event RoutedEventHandler OnPlayButtonClick
        {
            add { AddHandler(PlayButtonClickEvent, value); }
            remove { RemoveHandler(PlayButtonClickEvent, value); }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            RaiseEvent(new RoutedEventArgs(PlayButtonClickEvent));
        }

        private void ABOUT_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Play_MouseEnter(object sender, MouseEventArgs e)
        {

            Play.Margin = new Thickness(893, 152, 51, 434);

        }

        private void Play_MouseLeave(object sender, MouseEventArgs e)
        {


            Play.Margin = new Thickness(864, 152, 80, 434);
        }

        private void GUIDE_MouseEnter(object sender, MouseEventArgs e)
        {
            GUIDE.Margin = new Thickness(893, 360, 51, 246);

        }

        private void GUIDE_MouseLeave(object sender, MouseEventArgs e)
        {

            GUIDE.Margin = new Thickness(864, 360, 80, 246);
        }

        private void QUIT_MouseEnter(object sender, MouseEventArgs e)
        {
            QUIT.Margin = new Thickness(893, 546, 51, 46);

        }

        private void QUIT_MouseLeave(object sender, MouseEventArgs e)
        {

            QUIT.Margin = new Thickness(864, 546, 80, 46);
        }

        private void ABOUT_MouseEnter(object sender, MouseEventArgs e)
        {
            ABOUT.Content = "OUR";
        }

        private void ABOUT_MouseLeave(object sender, MouseEventArgs e)
        {
            ABOUT.Content = "ABOUT";
        }

        private void GUIDE_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
