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
