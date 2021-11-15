using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ContentSideBarGroup.xaml
    /// </summary>
    public partial class ContentSideBarGroup : UserControl
    {

        public int SelectedId
        {
            get { return (int)GetValue(SelectedIdProperty); }
            set { SetValue(SelectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register("SelectedId", typeof(int), typeof(ContentSideBarGroup), new PropertyMetadata(0));

        private List<ContentSideBar> listItem;

        public ContentSideBarGroup()
        {
            InitializeComponent();

            //listItem = new List<ContentSideBar>();
            //for (int i = 0; i < 4; i++)
            //{
            //    ContentSideBar content = new ContentSideBar();
            //    content.Id = i;
            //    if (SelectedId == content.Id)
            //    {
            //        content.Visibility = Visibility.Visible;
            //    }
            //    else
            //    {
            //        content.Visibility = Visibility.Hidden;
            //    }
            //    listItem.Add(content);
            //    gridContentSideBarGroup.Children.Add(content);
            //}
        }
    }
}
