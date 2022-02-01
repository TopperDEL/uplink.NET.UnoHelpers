using MvvmGen;
using MvvmGen.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Interfaces;
using uplink.NET.UnoHelpers.Messages;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel]
    [Inject(typeof(IAttachmentSelectService))]
    [Inject(typeof(IAttachmentViewModelFactory))]
    [Inject(typeof(IEventAggregator))]
    public partial class AttachmentContainerViewModel
    {
        [Property] ObservableCollection<AttachmentViewModel> _content = new ObservableCollection<AttachmentViewModel>();

        partial void OnInitialize()
        {
            Content.CollectionChanged += Content_CollectionChanged;
        }

        private void Content_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshCover();
        }

        [Command]
        public async Task SelectNewContentAsync()
        {
            var attachments = await AttachmentSelectService.GetAttachmentsAsync();
            foreach (var attachment in attachments)
            {
                var attachmentVm = AttachmentViewModelFactory.Create();

                await attachmentVm.SetAttachmentAsync(attachment);

                AddAttachment(attachmentVm);
            }
            if(attachments.Count > 0)
            {
                EventAggregator.Publish(new AttachmentAddingFinishedMessage());
            }
        }

        public void AddAttachment(AttachmentViewModel attachment)
        {
            Content.Add(attachment);

            EventAggregator.Publish(new AttachmentAddedMessage());
        }

        private void RefreshCover()
        {
            int index = 0;
            foreach (var attachment in Content)
            {
                if (index == 0)
                {
                    attachment.IsCover = true;
                }
                else
                {
                    attachment.IsCover = false;
                }
                index++;
            }
        }
    }
}
