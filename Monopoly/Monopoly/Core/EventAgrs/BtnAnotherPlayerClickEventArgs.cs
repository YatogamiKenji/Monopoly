using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Monopoly.Components;

namespace Monopoly
{
    public class BtnAnotherPlayerClickEventArgs : RoutedEventArgs
    {
        public int idPlayer { get; set; }

        public BtnAnotherPlayerClickEventArgs()
        {
        }
        public BtnAnotherPlayerClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public BtnAnotherPlayerClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
