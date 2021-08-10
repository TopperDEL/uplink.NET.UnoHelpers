using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;
using Windows.Storage;

namespace uplink.NET.UnoHelpers.Models
{
    public class StorageFileAttachment : Attachment
    {
        public StorageFile StorageFile { get; set; }

        public override async Task<Stream> GetAttachmentStreamAsync()
        {
            if (StorageFile != null)
            {
                return (await StorageFile.OpenReadAsync()).AsStream();
            }
            else
            {
                return AttachmentData;
            }
        }
    }
}
