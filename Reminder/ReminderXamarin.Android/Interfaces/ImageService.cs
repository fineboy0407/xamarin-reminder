using System.IO;
using Android.Graphics;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ImageService))]
namespace ReminderXamarin.Droid.Interfaces
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
            if (!File.Exists(targetFile) && File.Exists(sourceFile))
            {
                var downImg = DecodeSampledBitmapFromFile(sourceFile, requiredWidth, requiredHeight);
                using (var outStream = File.Create(targetFile))
                {
                    if (targetFile.ToLower().EndsWith("png"))
                    {
                        downImg.Compress(Bitmap.CompressFormat.Png, 100, outStream);
                    }
                    else
                    {
                        downImg.Compress(Bitmap.CompressFormat.Jpeg, 95, outStream);
                    }
                }
                downImg.Recycle();
            }
        }

        private static Bitmap DecodeSampledBitmapFromFile(string path, int requiredWidth, int requiredHeight)
        {
            // First decode with inJustDecodeBounds=true to check dimensions
            var options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(path, options);

            // Calculate inSampleSize
            options.InSampleSize = CalculateInSampleSize(options, requiredWidth, requiredHeight);

            // Decode bitmap with inSampleSize set
            options.InJustDecodeBounds = false;
            return BitmapFactory.DecodeFile(path, options);
        }

        private static int CalculateInSampleSize(BitmapFactory.Options options, int requiredWidth, int requiredHeight)
        {
            // Raw height and width of image
            var height = options.OutHeight;
            var width = options.OutWidth;
            var inSampleSize = 1;

            if (height > requiredHeight || width > requiredWidth)
            {
                var halfHeight = height / 2;
                var halfWidth = width / 2;

                // Calculate the largest inSampleSize value that is a power of 2 and keeps both
                // height and width larger than the requested height and width.
                while ((halfHeight / inSampleSize) > requiredHeight
                       && (halfWidth / inSampleSize) > requiredWidth)
                {
                    inSampleSize *= 2;
                }
            }

            return inSampleSize;
        }
    }
}