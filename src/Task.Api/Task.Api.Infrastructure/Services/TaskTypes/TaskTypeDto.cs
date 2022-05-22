using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Infrastructure.Services.TaskTypes
{
    public class TaskTypeDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
    }
}
