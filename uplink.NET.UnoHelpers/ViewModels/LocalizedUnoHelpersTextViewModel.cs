using MvvmGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace uplink.NET.UnoHelpers.ViewModels
{
    public class LocalizedUnoHelpersTextViewModel
    {
        public static string AccessGrant_Header { get; private set; }
        public static string ApiKey_Header { get; private set; }
        public static string BucketName_Header { get; private set; }
        public static string DeleteAttachment_Text { get; private set; }
        public static string HaveNoAccount_Text { get; private set; }
        public static string LoginButton_Content { get; private set; }
        public static string LoginVia_Title { get; private set; }
        public static string NoUploadInProgress_Text { get; private set; }
        public static string RegisterForFree_Text { get; private set; }
        public static string SatelliteAddress_Header { get; private set; }
        public static string Secret_Header { get; private set; }
        public static string SecretVerify_Header { get; private set; }
        public static string SetAttachmentAsCover_Text { get; private set; }
        public static string Upload_Text { get; private set; }
        public static string BucketCreateInfo_Text { get; set; }
        public static string LoginFailed { get; set; }

        static LocalizedUnoHelpersTextViewModel()
        {
            AccessGrant_Header = GetText("UH_AccessGrant-Header", "Access grant");
            ApiKey_Header = GetText("UH_ApiKey-Header", "API key");
            BucketName_Header = GetText("UH_BucketName-Header", "Bucket name");
            DeleteAttachment_Text = GetText("UH_DeleteAttachment-Text", "Delete");
            HaveNoAccount_Text = GetText("UH_HaveNoAccount-Text", "Have no account yet? ");
            LoginButton_Content = GetText("UH_LoginButton-Content", "Login");
            LoginVia_Title = GetText("UH_LoginVia-Title", "Login via");
            NoUploadInProgress_Text = GetText("UH_NoUploadInProgress-Text", "No pending transfer");
            RegisterForFree_Text = GetText("UH_RegisterForFree-Text", "Register for free");
            SatelliteAddress_Header = GetText("UH_SatelliteAddress-Header", "Satellite address");
            Secret_Header = GetText("UH_Secret-Header", "Secret");
            SecretVerify_Header = GetText("UH_SecretVerify-Header", "Secret verify");
            SetAttachmentAsCover_Text = GetText("UH_SetAttachmentAsCover-Text", "Set as cover");
            Upload_Text = GetText("UH_Upload-Text", "Uploads");
            BucketCreateInfo_Text = GetText("UH_BucketCreateInfo-Text", "The bucket will be created if it does not yet exist.");
            LoginFailed = GetText("UH_LoginFailed", "Login failed - please verify your credentials");
        }

        private static string GetText(string key, string fallback)
        {
            try
            {
                var text = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse()?.GetString(key);
                if (string.IsNullOrEmpty(text))
                {
                    text = fallback;
                }

                return text;
            }
            catch
            {
                return fallback;
            }
        }
    }
}
