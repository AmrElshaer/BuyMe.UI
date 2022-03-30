using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BuyMe.UI.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class BaseController : Controller
    {
        protected IMediator Mediator =>  HttpContext.RequestServices.GetService<IMediator>();
    }
}