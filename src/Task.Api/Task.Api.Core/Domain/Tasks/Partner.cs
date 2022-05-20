using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class Partner : BaseEntity
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public string? Phone { get; set; }
    }
}
