using System.Windows;

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
