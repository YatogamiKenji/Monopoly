using System.Windows;

namespace Monopoly
{
    public class BtnLandCardClickEventArgs : RoutedEventArgs
    {
        public Land land { get; set; }
        public int idCard { get; set; }

        public BtnLandCardClickEventArgs()
        {
        }
        public BtnLandCardClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public BtnLandCardClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
