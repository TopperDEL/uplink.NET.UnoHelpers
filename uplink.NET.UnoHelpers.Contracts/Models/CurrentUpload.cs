using System;
using System.Collections.Generic;
using System.Text;

namespace uplink.NET.UnoHelpers.Contracts.Models
{
    public class CurrentUpload
    {
        public string Description { get; set; }
        public int TotalBytes { get; set; }
        public int BytesCompleted { get; set; }
        public float PercentCompleted { get; set; }
    }
}
