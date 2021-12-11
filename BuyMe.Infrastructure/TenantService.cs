using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure
{
    public class TenantService : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private HttpContext _httpContext;
        private TenantDto _currentTenant;
        private readonly IMediator medatorR;
        public TenantService(IOptions<TenantSettings> tenantSettings,IMediator medatorR ,IHttpContextAccessor contextAccessor)
        {
            this.medatorR = medatorR;
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;
            InitConnection();

        }

        private void InitConnection()
        {
            if (_httpContext==null)
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
            else if (TryGetTenantFromSession(out var value))
            {
                SetTenant(value);
            }
            else if (_httpContext.Request.Cookies.TryGetValue("tenant", out var tenantId))
            {
                SetTenant(tenantId);
            }
            else if (_httpContext.Request.Headers.TryGetValue("tenant", out var tenId))
            {
                SetTenant(tenId);
            }
            else
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }

        private void SetTenant(string tenantId)
        {
            _currentTenant = medatorR.Send(new GetTenantByNameQuery(){TenantName=tenantId}).GetAwaiter().GetResult();
            Guard.Against.Null(_currentTenant,tenantId);
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
            if(string.IsNullOrEmpty(_httpContext.Session.GetString("tenant")))
            {
                return false;
            }
            value = _httpContext.Session.GetString("tenant");
            return true;
        }
    }
}
