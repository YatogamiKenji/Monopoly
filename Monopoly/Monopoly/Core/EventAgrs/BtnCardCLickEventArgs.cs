﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
