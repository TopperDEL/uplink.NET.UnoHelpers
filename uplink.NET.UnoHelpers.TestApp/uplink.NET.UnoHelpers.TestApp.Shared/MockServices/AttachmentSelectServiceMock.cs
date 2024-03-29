﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Interfaces;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.TestApp.MockServices
{
    public class AttachmentSelectServiceMock : IAttachmentSelectService
    {
        public async Task<List<Attachment>> GetAttachmentsAsync()
        {
            var guid = Guid.NewGuid().ToString();
#if WINDOWS_UWP
            var myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
            myFilter.AllowUI = false;
            Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient(myFilter);
            Windows.Web.Http.HttpResponseMessage result = await client.GetAsync(new Uri("https://picsum.photos/seed/" + guid + "/4000/3000"));
            MemoryStream mstream = new MemoryStream();
            await result.Content.WriteToStreamAsync(mstream.AsOutputStream());
            mstream.Position = 0;
            var attachment = new Attachment();
            attachment.AttachmentData = mstream;
            attachment.MimeType = "image/jpeg";
            attachment.Filename = guid + ".jpg";
#else
            var attachment = new Attachment();
            attachment.MimeType = "image/jpeg";
            attachment.Filename = "https://picsum.photos/seed/" + guid + "/4000/3000";
            
#endif

            return new List<Attachment>() { attachment };
        }
    }
}
