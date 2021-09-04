using System.Drawing.Imaging;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IImageService
    {
        string ResizeImage(string base64String, int width, int height, ImageFormat format);
    }
}