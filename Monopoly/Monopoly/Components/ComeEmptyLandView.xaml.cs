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
    /// Interaction logic for ComeEmptyLandView.xaml
    /// </summary>
    public partial class ComeEmptyLandView : UserControl
    {

        private Land _land;
        public Land land
        {
            get { return _land; }
            set { _land = value; }
        }

        


        public static readonly RoutedEvent BuyButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBuyButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

        public event RoutedEventHandler OnBuyButtonClick
        {
            add { AddHandler(BuyButtonClickEvent, value); }
            remove { RemoveHandler(BuyButtonClickEvent, value); }
        }

        private void BuyButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BuyButtonClickEvent));
        }



        public static readonly RoutedEvent UseCardButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

        public event RoutedEventHandler OnUseCardButtonClick
        {
            add { AddHandler(UseCardButtonClickEvent, value); }
            remove { RemoveHandler(UseCardButtonClickEvent, value); }
        }

        private void UseCardButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(UseCardButtonClickEvent));
        }



        public static readonly RoutedEvent SkipButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

        public event RoutedEventHandler OnSkipButtonClick
        {
            add { AddHandler(SkipButtonClickEvent, value); }
            remove { RemoveHandler(SkipButtonClickEvent, value); }
        }

        private void SkipButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SkipButtonClickEvent));
        }

        public ComeEmptyLandView(Land land)
        {
            this.DataContext = this;
            InitializeComponent();
            _land = land;
            landPriceButtonText.Text = _land.value.ToString();
            thisLandCard.setInfor(_land);
        }

    }
}