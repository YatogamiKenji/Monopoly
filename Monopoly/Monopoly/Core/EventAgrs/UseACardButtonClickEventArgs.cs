﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
    public class UseACardButtonClickEventArgs : RoutedEventArgs
    {
        public Power power { get; set; }
        public bool isEnoughMoneyToUse { get; set; }

        public UseACardButtonClickEventArgs()
        {
        }
        public UseACardButtonClickEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }
        public UseACardButtonClickEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}