﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Steam.Infrastructure
{
    public class Switcher
    {
        public static INavigate ContentArea { get; set; }
        public static void Switch(UserControl page)
        {
            ContentArea.Navigate(page);
        }

        public static INavigate ContentAreaShop { get; set; }
        public static void SwitchShop(UserControl page)
        {
            ContentAreaShop.Navigate(page);
        }
    }
}
