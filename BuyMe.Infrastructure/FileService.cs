using BuyMe.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace BuyMe.Infrastructure
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnv;

        public FileService(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        public string AddFile(string folderName, IFormFile file)
        {
            var filename = ContentDispositionHeaderValue
                                     .Parse(file.ContentDisposition)
                                     .FileName
                                     .Trim('"');
            var imgName = Guid.NewGuid().ToString() + $@"{filename}";
            filename = Path.Combine(Path.Combine(_hostEnv.WebRootPath, folderName), imgName);
            if (!System.IO.File.Exists(filename))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return imgName;
        }

        public void DeleteFile(string folderName, string fileName)
        {
            var filename = Path.Combine(Path.Combine(_hostEnv.WebRootPath, folderName), fileName);
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
        }
    }
}