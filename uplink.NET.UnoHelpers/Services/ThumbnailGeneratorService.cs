using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Interfaces;

namespace uplink.NET.UnoHelpers.Services
{
    public class ThumbnailGeneratorService : IThumbnailGeneratorService
    {
        public async Task<Stream> GenerateThumbnailForStreamAsync(Stream stream, string mimeType, int targetWidth, int targetHeight)
        {
            return await Task.Run(
                new Func<Stream>(
                    delegate ()
                    {
                        if(stream == null)
                        {
                            return GetPlaceHolderImageStream();
                        }
                        if (mimeType.Contains("image"))
                        {
                            try
                            {
                                stream.Position = 0;
                                using (SKBitmap sourceBitmap = SKBitmap.Decode(stream))
                                {
                                    SKImageInfo resizeInfo = new SKImageInfo(targetWidth, targetHeight);//, info.ColorType, info.AlphaType, info.ColorSpace);

                                    // Test whether there is more room in width or height
                                    if (Math.Abs(sourceBitmap.Width - targetWidth) > Math.Abs(sourceBitmap.Height - targetHeight))
                                    {
                                        // More room in width, so leave image width set to canvas width
                                        // and increase/decrease height by same ratio
                                        double widthRatio = (double)targetWidth / (double)sourceBitmap.Width;
                                        int newHeight = (int)Math.Floor(sourceBitmap.Height * widthRatio);

                                        resizeInfo.Height = newHeight;
                                    }
                                    else
                                    {
                                        // More room in height, so leave image height set to canvas height
                                        // and increase/decrease width by same ratio                 
                                        double heightRatio = (double)targetHeight / (double)sourceBitmap.Height;
                                        int newWidth = (int)Math.Floor(sourceBitmap.Width * heightRatio);

                                        resizeInfo.Width = newWidth;
                                    }

                                    using (SKBitmap scaledBitmap = sourceBitmap.Resize(resizeInfo, SKFilterQuality.High))
                                    {
                                        using (SKImage scaledImage = SKImage.FromBitmap(scaledBitmap))
                                        {
                                            using (SKData data = scaledImage.Encode())
                                            {
                                                return new MemoryStream(data.ToArray());
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                return GetPlaceHolderImageStream();
                            }
                        }
                        else
                        {
                            return GetPlaceHolderImageStream();
                        }
                    }
                )
            );
        }

        protected Stream GetPlaceHolderImageStream()
        {
            //ToDo: Add generic placeholder-image size 400*300
            return null;
        }
    }
}
