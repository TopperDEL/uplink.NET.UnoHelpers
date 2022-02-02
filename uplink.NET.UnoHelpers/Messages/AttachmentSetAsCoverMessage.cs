using System;
using System.Collections.Generic;
using System.Text;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Messages
{
    public class AttachmentSetAsCoverMessage
    {
        public Attachment SelectedAttachment { get; private set; }
        public AttachmentSetAsCoverMessage(Attachment selectedAttachment)
        {
            SelectedAttachment = selectedAttachment;
        }
    }
}
