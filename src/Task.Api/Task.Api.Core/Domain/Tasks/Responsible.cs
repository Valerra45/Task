using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class Responsible : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? LoginName { get; set; }
    }
}
