using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Monopoly.Layouts;

namespace Monopoly.Components
{
    public class BaseCenterMapView : UserControl
    {
        public virtual void setCountdown(double countdown)
        {
            Layouts.PanelCenterMap thisPanel = (Layouts.PanelCenterMap)FindName("thisPanel");
            thisPanel?.SetCountdown((int)Math.Ceiling(countdown));
        }
    }
}
