using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using uplink.NET.UnoHelpers.Contracts.Models;
using Windows.Storage;

namespace uplink.NET.UnoHelpers.Models
{
    public class StorageFileAttachment : Attachment
    {
        public StorageFile StorageFile { get; set; }

        public new Stream AttachmentData
        {
            get
            {
                return StorageFile?.OpenReadAsync().GetResults().AsStream();
            }
            set
            {

            }
        }
    }
}
