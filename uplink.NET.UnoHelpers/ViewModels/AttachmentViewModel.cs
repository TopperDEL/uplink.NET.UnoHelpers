using MvvmGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using uplink.NET.UnoHelpers.Contracts.Models;
using Windows.UI.Xaml.Media.Imaging;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel(ModelType = typeof(Attachment))]
    public partial class AttachmentViewModel
    {
        [Property] bool _isSelected;
        [Property] bool _isCover;
        [Property] BitmapImage _attachmentThumbnail;

        public void SetAttachment(Attachment attachment)
        {
            Model = attachment;
            AttachmentThumbnail = new BitmapImage();
            AttachmentThumbnail.SetSourceAsync(Model.AttachmentData.AsRandomAccessStream());
        }
    }
}
