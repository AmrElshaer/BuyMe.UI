using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IImageService
    {
        string ResizeIfLargerThan(string data, int maxWidth, int maxHeight);
    }
}
