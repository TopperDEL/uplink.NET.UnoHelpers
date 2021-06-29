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

        public event UploadQueueChangedEventHandler UploadQueueChangedEvent;

        List<UploadQueueEntry> _entries;
        Task _createTask;
        int _currentId;
        UploadQueueEntry _firstOne;
        UploadQueueEntry _secondOne;
        int _maxTimer = 0;

        public UploadQueueServiceMock()
        {
            _entries = new List<UploadQueueEntry>();
            _firstOne = new UploadQueueEntry { Id = _currentId++, Identifier = "Photo1.jpg", TotalBytes = 1024 * 100, BytesCompleted = 0 };
            _entries.Add(_firstOne);
            _secondOne = new UploadQueueEntry { Id = _currentId++, Identifier = "Photo2.jpg", TotalBytes = 1024 * 200, BytesCompleted = 0 };
            _entries.Add(_secondOne);
            _entries.Add(new UploadQueueEntry { Id = _currentId++, Identifier = "Photo3.jpg", TotalBytes = 1024 * 200, Failed = true, FailedMessage = "Network error, please try again" });

            _createTask = Task.Run(() => CreateTaskWork());
        }

        private async Task CreateTaskWork()
        {
            while (true)
            {
                await Task.Delay(1000);
                _maxTimer++;
                if (_currentId < 10)
                {
                    var entry = new UploadQueueEntry { Id = _currentId++, Identifier = Guid.NewGuid().ToString() + ".jpg", TotalBytes = 1024 * 100, BytesCompleted = 0 };
                    _entries.Add(entry);
                    UploadQueueChangedEvent?.Invoke(QueueChangeType.EntryAdded, entry);
                }

                _firstOne.BytesCompleted += 9048;
                UploadQueueChangedEvent?.Invoke(QueueChangeType.EntryUpdated, _firstOne);

                if (_firstOne.BytesCompleted > 5 * 3048)
                {
                    _secondOne.Failed = true;
                    _secondOne.FailedMessage = "Network error, please try again";
                    UploadQueueChangedEvent?.Invoke(QueueChangeType.EntryUpdated, _secondOne);
                }

                if (_firstOne.BytesCompleted >= _firstOne.TotalBytes)
                {
                    _entries.Remove(_firstOne);
                    UploadQueueChangedEvent?.Invoke(QueueChangeType.EntryRemoved, _firstOne);
                }

                if(_maxTimer > 15)
                {
                    foreach(var entry in _entries)
                    {
                        UploadQueueChangedEvent?.Invoke(QueueChangeType.EntryRemoved, entry);
                    }
                    return;
                }
            }
        }

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
            return await Task.FromResult(_entries);
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
