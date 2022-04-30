using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ByMe.Presentation.Controllers
{
    public class BaseController: Controller
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();
    }
}
