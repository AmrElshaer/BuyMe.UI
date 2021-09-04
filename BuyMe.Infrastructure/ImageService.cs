using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure
{
    public class ImageService:IImageService
    {
        #region Image Helper to resize image
        
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param na me="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var resultImage = new Bitmap(width, height);
            resultImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(resultImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width,
                    image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return resultImage;
        }
        private Image Base64ToImage(string img)
        {
            byte[] bytes = Convert.FromBase64String(img);
            Image result;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                result = Image.FromStream(ms);
            }

            return result;
        }
        #endregion
        public string ResizeImage(string base64String, int width, int height,ImageFormat format)
        {
            Guard.Against.Null(base64String, "Image");
            var img = Regex.Replace(base64String, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
            Image resizeImage =  ResizeImage(Base64ToImage(img), width, height);
            using MemoryStream ms1 = new MemoryStream();
            resizeImage.Save(ms1, format);
            return $"data:image/png;base64,{Convert.ToBase64String(ms1.ToArray())}";
        }
    }
}
