using BuyMe.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuyMe.UI.Areas.Inventory.Controllers
{
    public class UploadImageController : BaseController
    {
        private readonly IFileService _fileService;
        public UploadImageController(IFileService fileService)
        {
            _fileService = fileService;
        }
        // Upload method for chunk-upload and normal upload
        public void Save(IList<IFormFile> UploadFiles)
        {
            
            try
            {
                foreach (var file in UploadFiles)
                {
                    Response.Headers.Add("name", _fileService.AddFile("images",file));
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
        public void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var item in UploadFiles)
                {
                    _fileService.DeleteFile("images",item.FileName);
                }
              
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}
