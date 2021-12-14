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
    /// Interaction logic for BtnCard.xaml
    /// </summary>
    public delegate void BtnCardClickEventHandler(object sender, BtnCardClickEventArgs agrs);

    public partial class BtnCard : UserControl
    {
        public static RoutedEvent BtnCardCLickEvent =
            EventManager.RegisterRoutedEvent("OnSpinnedDice", RoutingStrategy.Bubble, typeof(BtnCardClickEventHandler), typeof(BtnCard));

        public event BtnCardClickEventHandler OnBtnCardClick
        {
            add
            {
                AddHandler(BtnCardCLickEvent, value);
            }
            remove
            {
                RemoveHandler(BtnCardCLickEvent, value);
            }
        }

        public Power Power
        {
            get { return (Power)GetValue(powerProperty); }
            set { SetValue(powerProperty, value); }
        }
        // Using a DependencyProperty as the backing store for power.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty powerProperty =
            DependencyProperty.Register("power", typeof(Power), typeof(BtnCard));




        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(BtnCard), new PropertyMetadata(0));




        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); setHighLight(); }
        }
        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(BtnCard), new PropertyMetadata(false));




        public bool EnoughMoneyToUse
        {
            get { return (bool)GetValue(EnoughMoneyToUseProperty); }
            set { SetValue(EnoughMoneyToUseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnoughMoneyToUse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnoughMoneyToUseProperty =
            DependencyProperty.Register("EnoughMoneyToUse", typeof(bool), typeof(BtnCard), new PropertyMetadata(true));




        public BtnCard()
        {
            InitializeComponent();
            
        }
        public BtnCard(Power power, int idCard, bool enoughMoneyToUse)
        {
            InitializeComponent();
            Id = idCard;
            Power = power;
            powerCard.Children.Add(new PowerCard(Power));
            EnoughMoneyToUse = enoughMoneyToUse;
            if (enoughMoneyToUse)
            {
                cantUseLayer.Opacity = 0;
            }
            else
            {
                cantUseLayer.Opacity = 0.3;
            }
        }

        void setHighLight()
        {
            if (IsSelected)
            {
                imgHighlight.Opacity = 1;
            }
            else
            {
                imgHighlight.Opacity = 0;
            }
        }

        private void BtnCardClickFunc(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new BtnCardClickEventArgs(BtnCardCLickEvent, this) { power = Power, idCard = Id });
        }

        private void HandleBtnCardHover(object sender, MouseEventArgs e)
        {
            imgHighlight.Opacity = 1;
            Cursor = Cursors.Hand;
        }
        private void HandleBtnCardLeave(object sender, MouseEventArgs e)
        {
            if (!IsSelected)
                imgHighlight.Opacity = 0;
        }
    }
}
