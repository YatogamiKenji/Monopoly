using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for NotiBoxOnlyText.xaml
    /// </summary>
    public partial class NotiBoxOnlyText : UserControl
    {



        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(NotiBoxOnlyText), new PropertyMetadata(""));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NotiBoxOnlyText), new PropertyMetadata(""));




        public NotiBoxOnlyText()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public NotiBoxOnlyText(string text, string color)
        {
            this.DataContext = this;
            InitializeComponent();
            if (text != "")
            {
                bool isBold = false;
                if (text[0] == '*')
                    isBold = true;
                string[] listText = text.Split("*");
                foreach (string t in listText)
                {
                    Run run = new Run(t);
                    if (isBold)
                        run.FontWeight = FontWeights.SemiBold;
                    notiText.Inlines.Add(run);
                    isBold = !isBold;
                }
            }
            Color = color;
        }
    }
}
