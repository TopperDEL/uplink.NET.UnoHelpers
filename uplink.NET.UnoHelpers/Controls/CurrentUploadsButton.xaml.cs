using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using uplink.NET.UnoHelpers.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace uplink.NET.UnoHelpers.Controls
{
    public sealed partial class CurrentUploadsButton : UserControl
    {
        CurrentUploadsViewModel _viewModel;
        public event EventHandler Clicked;

        public CurrentUploadsButton()
        {
            this.InitializeComponent();
            DataContext = _viewModel = (CurrentUploadsViewModel)Services.Initializer.GetServiceProvider().GetService(typeof(CurrentUploadsViewModel));
            _viewModel.SetDispatcher(this.Dispatcher);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}
