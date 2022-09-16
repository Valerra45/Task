using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Application.Services.DocumentTasks
{
    public class TaskProductRespons
    {
        public Guid ProductId { get; set; }

        public decimal Discount { get; set; }

        public decimal Margin { get; set; }

        public bool Enable { get; set; }
    }
}
