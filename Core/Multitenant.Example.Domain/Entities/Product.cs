using Multitenant.Example.Domain.Contracts;
using Multitenant.Example.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Domain.Entities
{
    public class Product : BaseEntity, IMustHaveTenant
    {
        public Product() { }
        public Product(string name, string description, int rate)
        {
            Name = name;
            Description = description;
            Rate = rate;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }
        public string TenantId { get; set; }
    }
}
