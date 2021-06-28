using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.Interfaces;
using uplink.NET.Models;

namespace uplink.NET.UnoHelpers.TestApp.MockServices
{
    public class UploadQueueServiceMock : IUploadQueueService
    {
        public bool UploadInProgress => throw new NotImplementedException();

        public Task AddObjectToUploadQueue(string bucketName, string key, string accessGrant, byte[] objectData, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task CancelUploadAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UploadQueueEntry>> GetAwaitingUploadsAsync()
        {
            List<UploadQueueEntry> entries = new List<UploadQueueEntry>();
            entries.Add(new UploadQueueEntry { Identifier = "Photo1.jpg", TotalBytes = 1024 * 100, BytesCompleted = 1024 * 33 });
            entries.Add(new UploadQueueEntry { Identifier = "Photo2.jpg", TotalBytes = 1024 * 200, BytesCompleted = 0 });
            entries.Add(new UploadQueueEntry { Identifier = "Photo3.jpg", TotalBytes = 1024 * 200, Failed = true, FailedMessage = "Network error, please try again" });

            return await Task.FromResult(entries);
        }

        public Task<int> GetOpenUploadCountAsync()
        {
            throw new NotImplementedException();
        }

        public void ProcessQueueInBackground()
        {
            throw new NotImplementedException();
        }

        public void StopQueueInBackground()
        {
            throw new NotImplementedException();
        }
    }
}
