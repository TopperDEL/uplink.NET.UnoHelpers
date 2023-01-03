using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace uplink.NET.UnoHelpers.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        LoginViewModel _vm;
        public LoginPage()
        {
            this.InitializeComponent();
            this.DataContextChanged += LoginPage_DataContextChanged;
            try
            {
                DataContext = _vm = (LoginViewModel)Services.Initializer.GetServiceProvider().GetService(typeof(LoginViewModel));
            }
            catch { }
        }

        private void LoginPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            _vm = DataContext as LoginViewModel;
        }

        private void TextBox_TextChanging(object sender, TextBoxTextChangingEventArgs e)
        {
            string bucketRegEx = "(?!^(\\d{1,3}\\.){3}\\d{1,3}$)(^[a-z0-9]([a-z0-9-]*(\\.[a-z0-9])?)*$)";
            TextBox sendingTextBox = (TextBox)sender;
            var newText = sendingTextBox.Text.ToLower();

            if (Regex.Match(newText, bucketRegEx).Success)
            {
                sendingTextBox.Text = newText;
            }
            else
            {
                if (newText.Length > 1)
                {
                    sendingTextBox.Text = newText.Substring(0, newText.Length - 1);
                }
                else
                {
                    sendingTextBox.Text = "";
                }
            }
            sendingTextBox.SelectionStart = sendingTextBox.Text.Length;
        }

        private void TextBox_KeyDown_CheckEnter(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter && _vm.LoginCommand.CanExecute(null))
            {
                _vm.LoginCommand.Execute(null);
            }
        }
    }
}
