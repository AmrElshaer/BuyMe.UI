using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IImageService
    {
        string ResizeImage(string base64String, int width, int height,ImageFormat format);
    }
}
