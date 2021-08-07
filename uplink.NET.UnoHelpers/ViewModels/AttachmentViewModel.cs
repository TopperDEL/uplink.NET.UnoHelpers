using MvvmGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel]
    public partial class AttachmentViewModel
    {
        [Property] bool _isSelected;
        [Property] bool _isCover;
        [Property] Stream _attachmentData;
        [Property] BitmapImage _attachmentThumbnail;
    }
}
