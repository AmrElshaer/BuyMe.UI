using Microsoft.AspNetCore.Http;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IFileService
    {
        void DeleteFile(string folderName, string fileName);

        string AddFile(string folderName, IFormFile file);
    }
}