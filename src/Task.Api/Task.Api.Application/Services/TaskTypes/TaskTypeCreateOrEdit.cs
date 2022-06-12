using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Application.Services.TaskTypes
{
    public class TaskTypeCreateOrEdit
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }
    }
}
