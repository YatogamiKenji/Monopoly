using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
    public class EndGameClickEventArgs : RoutedEventArgs
    {
        public Player player;

        public EndGameClickEventArgs()
        {
        }
        public EndGameClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public EndGameClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
