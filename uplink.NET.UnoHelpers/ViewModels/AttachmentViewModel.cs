using MvvmGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;
using Windows.UI.Xaml.Media.Imaging;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel(ModelType = typeof(Attachment))]
    public partial class AttachmentViewModel
    {
        private static BitmapImage _placeholder;
        static AttachmentViewModel()
        {
            _placeholder = new BitmapImage(new Uri("ms-appx:///Assets/White.png"));
        }

        [Property] bool _isSelected;
        [Property] bool _isCover;
        [Property] BitmapImage _attachmentThumbnail;
        [Property] bool _isLoaded;

        partial void OnInitialize()
        {
            AttachmentThumbnail = _placeholder;
        }

        public async Task SetAttachmentAsync(Attachment attachment)
        {
            Model = attachment;
            AttachmentThumbnail = new BitmapImage();
            await AttachmentThumbnail.SetSourceAsync(Model.AttachmentData.AsRandomAccessStream());

            IsLoaded = true;
        }
    }
}
