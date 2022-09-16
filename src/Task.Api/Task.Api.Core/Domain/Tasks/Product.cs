using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class Product : BaseEntity
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }

        public bool Group { get; set; }
    }
}
