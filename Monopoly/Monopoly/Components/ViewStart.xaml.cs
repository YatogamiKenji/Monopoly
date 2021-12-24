using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        public static readonly RoutedEvent AboutButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnAboutButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));

        public event RoutedEventHandler OnAboutButtonClick
        {
            add { AddHandler(AboutButtonClickEvent, value); }
            remove { RemoveHandler(AboutButtonClickEvent, value); }
        }

        private void ABOUT_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            RaiseEvent(new RoutedEventArgs(AboutButtonClickEvent));
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
            ABOUT.Content = "VỀ CHÚNG TÔI";
        }

        private void ABOUT_MouseLeave(object sender, MouseEventArgs e)
        {
            ABOUT.Content = "VỀ CHÚNG TÔI";
        }

        public static readonly RoutedEvent GuideButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnGuideButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));

        public event RoutedEventHandler OnGuideButtonClick
        {
            add { AddHandler(GuideButtonClickEvent, value); }
            remove { RemoveHandler(GuideButtonClickEvent, value); }
        }

        private void GUIDE_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            RaiseEvent(new RoutedEventArgs(GuideButtonClickEvent));
        }
    }
}
