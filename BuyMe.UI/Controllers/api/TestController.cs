using BuyMe.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UI.Controllers.api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TestController:BaseController
    {
        private readonly ICurrentUserService currentUserService;

        public TestController(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(currentUserService.CompanyId);
        }
    }
}
