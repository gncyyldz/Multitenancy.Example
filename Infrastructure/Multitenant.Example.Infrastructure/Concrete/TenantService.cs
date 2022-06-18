using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Multitenant.Example.Application.Abstractions;
using Multitenant.Example.Application.Settings;

namespace Multitenant.Example.Infrastructure.Concrete
{
    public class TenantService : ITenantService
    {
        readonly TenantSettings _tenantSettings;
        readonly Tenant _tenant;

        readonly HttpContext _httpContext; // Microsoft.AspNetCore.Http.Abstractions
        //Microsoft.Extensions.Options
        public TenantService(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor httpContextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = httpContextAccessor.HttpContext;
            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("TenantId", out var tenantId))
                {
                    _tenant = _tenantSettings.Tenants.FirstOrDefault(t => t.TenantId == tenantId);
                    if (_tenant == null) throw new Exception("Invalid tenant!");

                    //Eğer bu kullanıcı grubu/müşteri/kiracı paylaşımlı veritabanını kullanıyorsa connection string'i boş gelecektir.
                    if (string.IsNullOrEmpty(_tenant.ConnectionString))
                        _tenant.ConnectionString = _tenantSettings.Defaults.ConnectionString;
                }
            }
        }
        public string GetConnectionString() => _tenant?.ConnectionString;
        public string GetDatabaseProvider() => _tenantSettings.Defaults?.DbProvider;
        public Tenant GetTenant() => _tenant;
    }
}
