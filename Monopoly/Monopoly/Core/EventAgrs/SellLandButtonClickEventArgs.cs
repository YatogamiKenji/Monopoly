using System.Windows;

namespace Monopoly
{
    public class SellLandButtonClickEventArgs : RoutedEventArgs
    {
        public Land land { get; set; }
        public int index { get; set; }

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
