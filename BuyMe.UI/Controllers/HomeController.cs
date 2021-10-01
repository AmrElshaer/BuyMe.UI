using BuyMe.Application.Common.Models;
using BuyMe.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Linq;

namespace BuyMe.UI.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly TenantSettings option;

        public HomeController(IOptions<TenantSettings> option)
        {
            this.option = option.Value;
        }
        public IActionResult Index(string tenant)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                if (!option.Tenants.Any(a => a.Name == tenant))
                {
                    return NotFound();
                }
                HttpContext.Response.Cookies.Append("tenant", tenant);
            }
            return RedirectToAction(nameof(Dashboard));
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}