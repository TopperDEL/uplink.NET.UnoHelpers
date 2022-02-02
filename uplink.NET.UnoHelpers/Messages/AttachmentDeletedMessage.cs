using System;
using System.Collections.Generic;
using System.Text;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Messages
{
    public class AttachmentDeletedMessage
    {
        public Attachment DeletedAttachment { get; private set; }
        public AttachmentDeletedMessage(Attachment deletedAttachment)
        {
            DeletedAttachment = deletedAttachment;
        }
    }
}
