using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Application.Settings
{
    public class TenantSettings
    {
        public DefaultSetting Defaults { get; set; }
        public List<Tenant> Tenants { get; set; }
    }
}
