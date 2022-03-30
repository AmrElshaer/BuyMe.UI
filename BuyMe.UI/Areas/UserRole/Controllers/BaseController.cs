using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BuyMe.UI.Areas.UserRole.Controllers
{
    [Area("UserRole")]
    public class BaseController : Controller
    {
        protected IMediator Mediator =>  HttpContext.RequestServices.GetService<IMediator>();
    }
}