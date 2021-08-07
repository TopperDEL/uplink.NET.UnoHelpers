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

            var attachmentsVM = (AttachmentContainerViewModel)Services.Initializer.GetServiceProvider().GetService(typeof(AttachmentContainerViewModel));
            var attachment1 = new AttachmentViewModel();
            attachment1.AttachmentThumbnail = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://picsum.photos/seed/first/260/200"));
            attachmentsVM.AddAttachment(attachment1);
            var attachment2 = new AttachmentViewModel();
            attachment2.AttachmentThumbnail = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://picsum.photos/seed/second/260/200"));
            attachmentsVM.AddAttachment(attachment2);
            var attachment3 = new AttachmentViewModel();
            attachment3.AttachmentThumbnail = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://picsum.photos/seed/third/260/200"));
            attachmentsVM.AddAttachment(attachment3);
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
