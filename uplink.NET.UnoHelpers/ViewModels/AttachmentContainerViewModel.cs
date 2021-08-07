using MvvmGen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel]
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
