using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for CheatConsole.xaml
    /// </summary>
    public partial class CheatConsole : UserControl
    {
        public static string command_line;
        public CheatConsole()
        {
            InitializeComponent();

        }

        public static readonly RoutedEvent ExitButtonClickEvent =
           EventManager.RegisterRoutedEvent(nameof(OnExitButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CheatConsole));
        public static readonly RoutedEvent ExecuteButtonClickEvent =
          EventManager.RegisterRoutedEvent(nameof(OnExecuteButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CheatConsole));

        public event RoutedEventHandler OnExitButtonClick
        {
            add { AddHandler(ExitButtonClickEvent, value); }
            remove { RemoveHandler(ExitButtonClickEvent, value); }
        }
        public event RoutedEventHandler OnExecuteButtonClick
        {
            add { AddHandler(ExecuteButtonClickEvent, value); }
            remove { RemoveHandler(ExecuteButtonClickEvent, value); }
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            command_line = Command.Text;
            Command.Clear();
            RaiseEvent(new RoutedEventArgs(ExecuteButtonClickEvent));
            command_line = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ExitButtonClickEvent));
        }
    }
}

