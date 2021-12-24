using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ContentChessCell.xaml
    /// </summary>
    public partial class ContentChessCell : UserControl
    {


        private Storyboard sShaking; // sự kiện rung ô đất để lựa chọn;
        public ImageSource ImageCell
        {
            get { return (ImageSource)GetValue(ImageCellProperty); }
            set { SetValue(ImageCellProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCellProperty =
            DependencyProperty.Register("ImageCell", typeof(ImageSource), typeof(ContentChessCell));

        public static readonly RoutedEvent ButtonChessCellClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonChessCellClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContentChessCell));

        public event RoutedEventHandler OnButtonChessCellClick
        {
            add { AddHandler(ButtonChessCellClickEvent, value); }
            remove { RemoveHandler(ButtonChessCellClickEvent, value); }
        }

        public static readonly DependencyProperty TitleProperty =
           DependencyProperty.Register("ang", typeof(string), typeof(popup), new PropertyMetadata(string.Empty));
        public string ang
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ContentChessCell()
        {
            InitializeComponent();
        

        }

        private void ButChessCell_Click(object sender, RoutedEventArgs e)
        {
            Sound.Planet();
            RaiseEvent(new RoutedEventArgs(ButtonChessCellClickEvent));
        }

        public void StartShaking()
        {
          
            sShaking = (Storyboard)ButChessCell.FindResource("rung");
            sShaking.Begin();
        }
        public void StopShaking()
        {
            sShaking.Stop();
        }
        
        // set màu phân biệt ô đất của người chơi khi mua đất
        public void MarkLand(int indexPlayer)
        {
            
            Border markLand = (Border)ButChessCell.Template.FindName("ColorLandPlayer", ButChessCell);

            //  MessageBox.Show(markLand.Background.ToString());
            
            if (indexPlayer == 0)
            {
                markLand.Background = Brushes.Red;
            }
           else if(indexPlayer == 1)
            {
                markLand.Background = Brushes.Violet;
            }
            else if (indexPlayer == 2)
            {
                markLand.Background = Brushes.Blue;
            }
            else if (indexPlayer == 3)
            {
                markLand.Background = Brushes.Yellow;
            }
            else
            {
                markLand.Background = Brushes.Transparent;
            }    

        }

        //Thêm sao vào ô cờ
        public void AddStar(int LevelLand)
        {
            Grid starLevel = (Grid)ButChessCell.Template.FindName("gridStarLevel", ButChessCell);
            var imageStarSource = new BitmapImage(new Uri( @"/Monopoly;component/Images/cell/player_land_star.png", UriKind.Relative));
            var imageStar = new Image { Source = imageStarSource };
            Grid.SetRow(imageStar, 5 - LevelLand);
            starLevel.Children.Add(imageStar);
        }
        //Loại bỏ đánh dấu và sao khi bán đát

        public void RemoveMarkLand()
        {
            Border markLand = (Border)ButChessCell.Template.FindName("ColorLandPlayer", ButChessCell);
            markLand.Background = Brushes.Transparent;
            Grid starLevel = (Grid)ButChessCell.Template.FindName("gridStarLevel", ButChessCell);
            starLevel.Children.Clear();
        }

        //hạ 2 level đất
        public void subStar(int numStar)
        {
            Grid starLevel = (Grid)ButChessCell.Template.FindName("gridStarLevel", ButChessCell);
            for (int i = 0; i < numStar; i++)
                if (starLevel.Children.Count > 0) starLevel.Children.RemoveAt(starLevel.Children.Count - 1);
        }

        private void ButChessCell_MouseEnter(object sender, MouseEventArgs e)
        {
            //popup.Visibility = Visibility.Visible;

        }

        private void ButChessCell_MouseLeave(object sender, MouseEventArgs e)
        {
            //popup.Visibility = Visibility.Collapsed;

        }
    }
}
