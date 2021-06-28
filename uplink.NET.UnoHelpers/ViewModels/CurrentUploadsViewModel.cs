using MvvmGen;
using MvvmGen.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.Interfaces;
using uplink.NET.Models;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [Inject(typeof(IEventAggregator))]
    [Inject(typeof(IUploadQueueService))]
    [ViewModel]
    public partial class CurrentUploadsViewModel
    {
        [Property] private ObservableCollection<UploadQueueEntry> _uploadQueueEntries;

        partial void OnInitialize()
        {
            UploadQueueEntries = new ObservableCollection<UploadQueueEntry>();
        }
        
        [Command]
        public async Task RefreshAsync()
        {
            var entries = await UploadQueueService.GetAwaitingUploadsAsync();
            UploadQueueEntries.Clear();
            foreach (var entry in entries)
            {
                UploadQueueEntries.Add(entry);
            }
        }
    }
}
