using System.Windows;

namespace Monopoly
{
    public class BtnCardClickEventArgs : RoutedEventArgs
    {
        public Power power { get; set; }
        public int idCard { get; set; }

        public BtnCardClickEventArgs()
        {
        }
        public BtnCardClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public BtnCardClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
