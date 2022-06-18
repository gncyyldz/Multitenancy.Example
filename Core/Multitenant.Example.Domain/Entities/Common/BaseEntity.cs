using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
