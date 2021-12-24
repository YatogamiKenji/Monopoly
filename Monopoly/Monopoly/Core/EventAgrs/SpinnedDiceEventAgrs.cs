using System.Windows;

namespace Monopoly
{
    public class SpinnedDiceEventAgrs : RoutedEventArgs
    {
        public int valueOfDice { get; set; }

        public SpinnedDiceEventAgrs()
        {
        }
        public SpinnedDiceEventAgrs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public SpinnedDiceEventAgrs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
