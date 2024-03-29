﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace uplink.NET.UnoHelpers.Contracts.Models
{
    public class Attachment
    {
        public Stream AttachmentData { get; set; }
        public string MimeType { get; set; }
        public string Filename { get; set; }

        public virtual async Task<Stream> GetAttachmentStreamAsync()
        {
            return AttachmentData;
        }
    }
}
