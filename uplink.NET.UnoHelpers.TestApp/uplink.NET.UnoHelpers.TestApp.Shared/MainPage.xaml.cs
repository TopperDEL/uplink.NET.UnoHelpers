﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uplink.NET.UnoHelpers.TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CurrentUploads.Clicked += (sender, e) => { NavigateToCurrentUploadsPage(); };
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UnoHelpers.Views.LoginPage));
        }

        private void CurrentUploadsPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToCurrentUploadsPage();
        }

        private void NavigateToCurrentUploadsPage()
        {
            this.Frame.Navigate(typeof(UnoHelpers.Views.CurrentUploadsPage));
        }
    }
}
