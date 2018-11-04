using System;
using System.IO;
using CoreGraphics;
using ReminderXamarin.iOS.Interfaces;
using ReminderXamarin.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]
namespace ReminderXamarin.iOS.Interfaces
{
    public class ImageService : IImageService
    {
        /// <summary>
        /// Resizes the image at sourceFile with the requested width and height and stores it at the provided target.
        /// </summary>
        /// <param name="sourceFile">Source file.</param>
        /// <param name="targetFile">Target file.</param>
        /// <param name="requiredWidth">Required width.</param>
        /// <param name="requiredHeight">Required height.</param>
        public void ResizeImage(string sourceFile, string targetFile, int requiredWidth, int requiredHeight)
        {
            if (File.Exists(sourceFile) && !File.Exists(targetFile))
            {
                using (var sourceImage = UIImage.FromFile(sourceFile))
                {
                    var sourceSize = sourceImage.Size;
                    var maxResizeFactor = Math.Min(requiredWidth / sourceSize.Width, requiredHeight / sourceSize.Height);

                    if (!Directory.Exists(Path.GetDirectoryName(targetFile)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(targetFile));
                    }

                    if (maxResizeFactor > 0.9)
                    {
                        File.Copy(sourceFile, targetFile);
                    }
                    else
                    {
                        var width = maxResizeFactor * sourceSize.Width;
                        var height = maxResizeFactor * sourceSize.Height;

                        UIGraphics.BeginImageContextWithOptions(new CGSize((float)width, (float)height), true, 1.0f);

                        sourceImage.Draw(new CGRect(0, 0, (float)width, (float)height));

                        var resultImage = UIGraphics.GetImageFromCurrentImageContext();
                        UIGraphics.EndImageContext();


                        if (targetFile.ToLower().EndsWith("png"))
                        {
                            resultImage.AsPNG().Save(targetFile, true);
                        }
                        else
                        {
                            resultImage.AsJPEG().Save(targetFile, true);
                        }
                    }
                }
            }
        }
    }
}