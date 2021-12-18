using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
    public class UseACardButtonClickEventArgs : RoutedEventArgs
    {
        public Power power { get; set; }
        public bool isEnoughMoneyToUse { get; set; }

        public UseACardButtonClickEventArgs()
        {
        }
        public UseACardButtonClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public UseACardButtonClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }

    public class RemoveCardButtonClickEventArgs : RoutedEventArgs
    {
        public Power power { get; set; }
        public bool isEnoughMoneyToUse { get; set; }

        public RemoveCardButtonClickEventArgs()
        {
        }
        public RemoveCardButtonClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public RemoveCardButtonClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }

    public class SellLandButtonClickEventArgs : RoutedEventArgs
    {
        public Land land { get; set; }

        public SellLandButtonClickEventArgs()
        {
        }
        public SellLandButtonClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public SellLandButtonClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
