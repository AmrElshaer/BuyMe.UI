using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text;

namespace BuyMe.Infrastructure
{
    public class TenantService : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private HttpContext _httpContext;
        private TenantDto _currentTenant;
        private ILogger<TenantService> _logger;
        private readonly IMediator medatorR;
        public TenantService(IOptions<TenantSettings> tenantSettings, ILogger<TenantService> logger, IMediator medatorR, IHttpContextAccessor contextAccessor)
        {
            this.medatorR = medatorR;
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            InitConnection();
            _logger = logger;
            _logger.LogInformation($"Tenant Name {_currentTenant.TenantName} Tenant connection {_currentTenant.ConnectionString}");

        }

        private void InitConnection()
        {

            if (_httpContext != null && TryGetTenant(out string tenant))
                SetTenant(tenant);
            else
                SetDefaultConnectionStringToCurrentTenant();

        }
        private bool TryGetTenant(out string tenant)
        {

            if (TryGetTenantFromSession(out tenant)
                || TryGetTenantFromCookies(out tenant)
                || TryGetTenantFromHeaders(out tenant))
            {
                return true;
            }
            return false;
        }
        private bool TryGetTenantFromCookies(out string tenant)
        {
            return _httpContext.Request.Cookies.TryGetValue("tenant", out tenant);

        }
        private bool TryGetTenantFromHeaders(out string tenant)
        {
            tenant = _httpContext.Request.Headers["tenant"].FirstOrDefault();
            return tenant != null;

        }
        private void SetTenant(string tenantId)
        {
            _currentTenant = medatorR.Send(new GetTenantByNameQuery() { TenantName = tenantId }).GetAwaiter().GetResult();
            Guard.Against.Null(_currentTenant, tenantId);
            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }
        private void SetDefaultConnectionStringToCurrentTenant()
        {
            _currentTenant ??= new();
            _currentTenant.ConnectionString = _tenantSettings.DefaultConnection;
        }
        public string GetConnectionString()
        {
            return _currentTenant?.ConnectionString;
        }

        public TenantDto GetTenant()
        {
            return _currentTenant;
        }
        private bool TryGetTenantFromSession(out string value)
        {
            value = null;
            if (string.IsNullOrEmpty(_httpContext.Session.GetString("tenant")))
            {
                return false;
            }
            value = _httpContext.Session.GetString("tenant");
            return true;
        }
    }
}
