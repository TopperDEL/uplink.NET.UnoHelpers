using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Contracts.Interfaces
{
    public interface IAttachmentSelectService
    {
        Task<List<Attachment>> GetAttachmentsAsync();
    }
}
