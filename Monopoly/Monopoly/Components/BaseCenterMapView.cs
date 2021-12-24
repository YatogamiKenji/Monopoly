using System;
using System.Windows.Controls;

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
