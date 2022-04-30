using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ByMe.Presentation.Areas.UserRole.Controllers
{
    [Area("UserRole")]
    public class BaseController : Controller
    {
        protected IMediator Mediator =>  HttpContext.RequestServices.GetService<IMediator>();
    }
}