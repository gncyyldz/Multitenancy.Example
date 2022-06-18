using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Application.Settings
{
    public class Tenant
    {
        public string Name { get; set; }
        public string TenantId { get; set; }
        public string ConnectionString { get; set; }
    }
}
