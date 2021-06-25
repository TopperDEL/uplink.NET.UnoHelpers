using System;
using System.Collections.Generic;
using System.Text;

namespace uplink.NET.UnoHelpers.Contracts.Interfaces
{
    public interface ICurrentUploadsService
    {
        bool HasCurrentUploads { get; }
    }
}
