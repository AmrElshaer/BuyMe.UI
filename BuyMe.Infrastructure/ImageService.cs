using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure
{
    public class ImageService:IImageService
    {
        public string ResizeIfLargerThan(string data, int maxWidth, int maxHeight)
        {
            Guard.Against.Null(data,"Image");
            var result = Regex.Replace(data, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
            var bytes = Convert.FromBase64String(result);
            var image = new MagickImage(bytes);
            var size = new MagickGeometry(maxWidth, maxHeight);
            image.Resize(size);
            return string.Concat("data:image/png;base64,", Convert.ToBase64String(image.ToByteArray()));
        }
    }
}
