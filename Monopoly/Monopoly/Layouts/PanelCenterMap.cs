﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Monopoly.Layouts
{
    public class PanelCenterMap : ContentControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PanelCenterMap), new PropertyMetadata("TIÊU ĐỀ MẶC ĐỊNH"));

        public string CountdownStr
        {
            get { return (string)GetValue(CountdownStrProperty); }
            set { SetValue(CountdownStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CountdownStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountdownStrProperty =
            DependencyProperty.Register("CountdownStr", typeof(string), typeof(PanelCenterMap), new PropertyMetadata("00 : 00"));


        static PanelCenterMap()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PanelCenterMap), new FrameworkPropertyMetadata(typeof(PanelCenterMap)));
        }

        public void SetCountdown(int countdown)
        {
            if (countdown < 0)
                countdown = 0;
            int m = countdown / 60;
            int s = countdown % 60;
            CountdownStr = (m < 10 ? "0" : "") + m + " : " + (s < 10 ? "0" : "") + s;
        }


        
    }
}
