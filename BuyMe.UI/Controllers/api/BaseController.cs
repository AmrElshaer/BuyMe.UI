using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace BuyMe.UI.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator != null ? _mediator : HttpContext.RequestServices.GetService<IMediator>();
    }
}
