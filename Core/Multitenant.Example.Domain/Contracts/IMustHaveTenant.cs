using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Domain.Contracts
{
    public interface IMustHaveTenant
    {
        string TenantId { get; set; }
    }
}
