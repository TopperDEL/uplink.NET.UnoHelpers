using MvvmGen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.Interfaces;
using uplink.NET.Models;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [Inject(typeof(IUploadQueueService))]
    [ViewModel]
    public partial class UploadQueueEntryViewModel
    {
        [Property] private int _id;
        [Property] private string _key;
        [Property] private string _identifier;
        [Property] private int _bytesCompleted;
        [Property] private int _totalBytes;
        [Property] private bool _failed;
        [Property] private string _failedMessage;

        public void Load(UploadQueueEntry entry)
        {
            Key = entry.Key;
            Id = entry.Id;
            Identifier = entry.Identifier;
            Failed = entry.Failed;
            FailedMessage = entry.FailedMessage;
            BytesCompleted = entry.BytesCompleted;
            TotalBytes = entry.TotalBytes;
        }

        [Command]
        public async Task RetryAsync()
        {
            await UploadQueueService.RetryAsync(Key);
        }
    }
}
