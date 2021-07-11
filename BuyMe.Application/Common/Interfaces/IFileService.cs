using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IFileService
    {
        void DeleteFile(string folderName, string fileName);
        string AddFile(string folderName, IFormFile file);
    }
}
