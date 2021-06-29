using MvvmGen;
using System;
using System.Collections.Generic;
using System.Text;
using uplink.NET.Models;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [ViewModel]
    public partial class UploadQueueEntryViewModel
    {
        [Property] private int _id;
        [Property] private string _identifier;
        [Property] private int _bytesCompleted;
        [Property] private int _totalBytes;
        [Property] private bool _failed;
        [Property] private string _failedMessage;

        public void Load(UploadQueueEntry newEntry)
        {
            Id = newEntry.Id;
            Identifier = newEntry.Identifier;
            Failed = newEntry.Failed;
            FailedMessage = newEntry.FailedMessage;
            BytesCompleted = newEntry.BytesCompleted;
            TotalBytes = newEntry.TotalBytes;
        }
    }
}
