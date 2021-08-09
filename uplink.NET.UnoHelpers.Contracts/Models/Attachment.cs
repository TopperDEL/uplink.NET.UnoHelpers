using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace uplink.NET.UnoHelpers.Contracts.Models
{
    public class Attachment
    {
        public Stream AttachmentData { get; set; }
        public string MimeType { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
    }
}
