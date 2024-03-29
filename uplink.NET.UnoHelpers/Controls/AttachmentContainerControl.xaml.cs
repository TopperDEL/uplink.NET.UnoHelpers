﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using uplink.NET.UnoHelpers.Contracts.Models;
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
    public sealed partial class AttachmentContainerControl : UserControl
    {
        AttachmentContainerViewModel _viewModel;

        public bool CanSetAttachmentAsCover
        {
            get { return (bool)GetValue(CanSetAttachmentAsCoverProperty); }
            set { SetValue(CanSetAttachmentAsCoverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanSetAttachmentAsCover.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanSetAttachmentAsCoverProperty =
            DependencyProperty.Register("CanSetAttachmentAsCover", typeof(bool), typeof(AttachmentContainerControl), new PropertyMetadata(null));

        public bool CanDeleteAttachment
        {
            get { return (bool)GetValue(CanDeleteAttachmentProperty); }
            set { SetValue(CanDeleteAttachmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanSetAttachmentAsCover.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanDeleteAttachmentProperty =
            DependencyProperty.Register("CanDeleteAttachment", typeof(bool), typeof(AttachmentContainerControl), new PropertyMetadata(null));


        public AttachmentContainerControl()
        {
            this.InitializeComponent();
            DataContext = _viewModel = (AttachmentContainerViewModel)Services.Initializer.GetServiceProvider().GetService(typeof(AttachmentContainerViewModel));
        }

        public List<Attachment> GetAttachments()
        {
            return _viewModel.Content.Select(c=>c.GetModel()).ToList();
        }

        public void ClearAttachments()
        {
            _viewModel.Content.Clear();
        }
    }
}
