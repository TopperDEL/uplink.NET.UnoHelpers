using MvvmGen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Interfaces;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel]
    [Inject(typeof(IAttachmentSelectService))]
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
            var attachment = await AttachmentSelectService.GetAttachmentAsync();
            var attachmentVm = new AttachmentViewModel();
            
            AddAttachment(attachmentVm);

            await attachmentVm.SetAttachmentAsync(attachment);
        }

        public void AddAttachment(AttachmentViewModel attachment)
        {
            Content.Add(attachment);
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
