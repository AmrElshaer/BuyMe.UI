using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Models;
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
        private Tenant _currentTenant;
        public TenantService(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor contextAccessor)
        {
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
            _currentTenant = _tenantSettings.Tenants.Where(a => a.Name == tenantId).FirstOrDefault();
            if (_currentTenant == null) throw new Exception("Invalid Tenant!");
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
      
        public Tenant GetTenant()
        {
            return _currentTenant;
        }
    }
}
