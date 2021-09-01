using MvvmGen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.Interfaces;
using uplink.NET.Models;
using System.Linq;

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
        [Property] private string _fileExtension;

        public void Load(UploadQueueEntry entry)
        {
            Key = entry.Key;
            Id = entry.Id;
            Identifier = entry.Identifier;
            Failed = entry.Failed;
            FailedMessage = entry.FailedMessage;
            BytesCompleted = entry.BytesCompleted;
            TotalBytes = entry.TotalBytes;
            if (entry.Identifier != null && entry.Identifier.Contains("."))
            {
                FileExtension = entry.Identifier.Split(new[] { '.' }).Last().ToUpperInvariant();
            }
            else
            {
                FileExtension = "OBJ";
            }
        }

        [Command]
        public async Task RetryAsync()
        {
            await UploadQueueService.RetryAsync(Key);
        }
    }
}
