using MvvmGen;
using MvvmGen.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Interfaces;
using uplink.NET.UnoHelpers.Contracts.Models;
using uplink.NET.UnoHelpers.Messages;
using Windows.UI.Xaml.Media.Imaging;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel(ModelType = typeof(Attachment))]
    [Inject(typeof(IThumbnailGeneratorService))]
    [Inject(typeof(IEventAggregator))]
    [Inject(typeof(LocalizedUnoHelpersTextViewModel))]
    [ViewModelGenerateFactory]
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
        [Property] private LocalizedUnoHelpersTextViewModel _texts;

        private Stream _thumbnail;

        partial void OnInitialize()
        {
            Texts = LocalizedUnoHelpersTextViewModel;
            AttachmentThumbnail = _placeholder;
        }

        public async Task SetAttachmentAsync(Attachment attachment)
        {
            Model = attachment;
            _thumbnail = await ThumbnailGeneratorService.GenerateThumbnailForStreamAsync(await attachment.GetAttachmentStreamAsync(), attachment.MimeType, 400, 300);

            if (_thumbnail != null)
            {
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(_thumbnail.AsRandomAccessStream());

                AttachmentThumbnail = bitmapImage;
            }

            IsLoaded = true;
        }

        public void SetAttachmentFromURL(Attachment attachment, Uri uri)
        {
            Model = attachment;
            AttachmentThumbnail = new BitmapImage(uri);

            IsLoaded = true;
        }

        public Attachment GetModel()
        {
            return Model;
        }

        [Command]
        public async Task DeleteAttachmentAsync()
        {
            EventAggregator.Publish(new AttachmentDeletedMessage(Model));
        }

        [Command]
        public async Task SetAttachmentAsCoverAsync()
        {
            EventAggregator.Publish(new AttachmentSetAsCoverMessage(Model));
        }

        ~AttachmentViewModel()
        {
            if(_thumbnail != null)
            {
                _thumbnail.Dispose();
                _thumbnail = null;
            }
        }
    }
}
