using System.Collections.Generic;
using System.Windows;
using Monopoly.Components;

namespace Monopoly
{
    public class GoClickEventArgs : RoutedEventArgs
    {
        public List<PlayerShow> showPlayers { get; set; }
        public bool GameMode { get; set; }
        public int NumberTurns { get; set; }

        public GoClickEventArgs()
        {
        }
        public GoClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public GoClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
