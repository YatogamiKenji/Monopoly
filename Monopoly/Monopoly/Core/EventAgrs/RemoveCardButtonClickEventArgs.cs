using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
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
}
