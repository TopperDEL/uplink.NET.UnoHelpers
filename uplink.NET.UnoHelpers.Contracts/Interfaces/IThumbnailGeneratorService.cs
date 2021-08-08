using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace uplink.NET.UnoHelpers.Contracts.Interfaces
{
    public interface IThumbnailGeneratorService
    {
        Task<Stream> GenerateThumbnailForStreamAsync(Stream stream, string mimeType, int targetWidth, int targetHeight);
    }
}
