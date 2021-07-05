using MvvmGen;
using MvvmGen.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.Interfaces;
using uplink.NET.Models;
using System.Linq;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [Inject(typeof(IEventAggregator))]
    [Inject(typeof(IUploadQueueService))]
    [ViewModel]
    public partial class CurrentUploadsViewModel
    {
        [Property] private ObservableCollection<UploadQueueEntryViewModel> _uploadQueueEntries;
        [Property] private bool _hasCurrentUpload;
        [Property] private bool _hasFailedUploads;
        [Property] private int _currentUploadCount;

        partial void OnInitialize()
        {
            UploadQueueEntries = new ObservableCollection<UploadQueueEntryViewModel>();
            UploadQueueService.UploadQueueChangedEvent += UploadQueueService_UploadQueueChangedEvent;
            RefreshAsync();
        }

        private Windows.UI.Core.CoreDispatcher _dispatcher;
        public void SetDispatcher(Windows.UI.Core.CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        private async void UploadQueueService_UploadQueueChangedEvent(QueueChangeType queueChangeType, UploadQueueEntry entry)
        {
            await _dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                switch (queueChangeType)
                {
                    case QueueChangeType.EntryAdded:
                        if (UploadQueueEntries.Where(b => b.Id == entry.Id).Count() == 0)
                        {
                            var newEntryVM = new UploadQueueEntryViewModel();
                            newEntryVM.Load(entry);
                            UploadQueueEntries.Add(newEntryVM);
                        }
                        break;
                    case QueueChangeType.EntryUpdated:
                        if (UploadQueueEntries.Where(b => b.Id == entry.Id).Count() == 0)
                        {
                            var newEntryVM = new UploadQueueEntryViewModel();
                            newEntryVM.Load(entry);
                            UploadQueueEntries.Add(newEntryVM);
                            return;
                        }
                        var existing = UploadQueueEntries.Where(e => e.Id == entry.Id).FirstOrDefault();
                        existing.Load(entry);
                        break;
                    case QueueChangeType.EntryRemoved:
                        var toDelete = UploadQueueEntries.Where(e => e.Id == entry.Id).FirstOrDefault();
                        if (toDelete != null)
                        {
                            UploadQueueEntries.Remove(toDelete);
                        }
                        break;
                }

                RefreshMetafields();
            });
        }

        [Command]
        public async Task RefreshAsync()
        {
            var entries = await UploadQueueService.GetAwaitingUploadsAsync();
            UploadQueueEntries.Clear();
            foreach (var entry in entries)
            {
                var newEntryVM = new UploadQueueEntryViewModel();
                newEntryVM.Load(entry);
                UploadQueueEntries.Add(newEntryVM);
            }

            RefreshMetafields();
        }

        private void RefreshMetafields()
        {
            HasCurrentUpload = UploadQueueEntries.Count > 0;
            CurrentUploadCount = UploadQueueEntries.Count;
            HasFailedUploads = UploadQueueEntries.Where(u => u.Failed).Count() > 0;
        }

        [Command]
        public void NavigateBack()
        {
            EventAggregator.Publish(new Messages.NavigateBackFromCurrentUploadsMessage());
        }

        public void OnNavigatedAway()
        {
            UploadQueueService.UploadQueueChangedEvent -= UploadQueueService_UploadQueueChangedEvent;
        }
    }
}
