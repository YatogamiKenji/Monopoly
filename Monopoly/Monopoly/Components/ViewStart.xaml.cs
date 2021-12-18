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

        private void QUIT_Click(object sender, RoutedEventArgs e)
        {
            mp.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\buttonBack.mp3"));
            mp.Play();
            Window.GetWindow(this).Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            mp.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\buttonStart.mp3"));
            mp.Play();
            Setup setup = new Setup();
            views.Content = setup;
        }

        private void ABOUT_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Play_MouseEnter(object sender, MouseEventArgs e)
        {
            Play.Content = "SETUP!";
            rocketstart.PlacementTarget = Play;
            rocketstart.Placement = PlacementMode.Right;
            rocketstart.IsOpen = true;

        }

        private void Play_MouseLeave(object sender, MouseEventArgs e)
        {
            rocketstart.Visibility = Visibility.Collapsed;
            rocketstart.IsOpen = false;
            Play.Content = "PLAY";
        }

        private void GUIDE_MouseEnter(object sender, MouseEventArgs e)
        {
            rocketstart.PlacementTarget = GUIDE;
            rocketstart.Placement = PlacementMode.Right;
            rocketstart.IsOpen = true;
            GUIDE.Content = "Learning!";
        }

        private void GUIDE_MouseLeave(object sender, MouseEventArgs e)
        {
            GUIDE.Content = "GUIDE";
            rocketstart.Visibility = Visibility.Collapsed;
            rocketstart.IsOpen = false;
        }

        private void QUIT_MouseEnter(object sender, MouseEventArgs e)
        {
            rocketstart.PlacementTarget = QUIT;
            rocketstart.Placement = PlacementMode.Right;
            rocketstart.IsOpen = true;
            QUIT.Content = "You sure?";
        }

        private void QUIT_MouseLeave(object sender, MouseEventArgs e)
        {
            QUIT.Content = "QUIT";
            rocketstart.Visibility = Visibility.Collapsed;
            rocketstart.IsOpen = false;
        }

        private void ABOUT_MouseEnter(object sender, MouseEventArgs e)
        {
            ABOUT.Content = "OUR";
        }

        private void ABOUT_MouseLeave(object sender, MouseEventArgs e)
        {
            ABOUT.Content = "ABOUT";
        }
    }
}
