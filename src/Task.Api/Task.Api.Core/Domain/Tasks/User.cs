using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
