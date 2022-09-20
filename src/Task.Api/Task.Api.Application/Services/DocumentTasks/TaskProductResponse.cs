using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Products;

namespace Tasks.Api.Application.Services.DocumentTasks
{
    public class TaskProductResponse
    {
        public ProductResponse? Product { get; set; }

        public decimal Discount { get; set; }

        public decimal Margin { get; set; }

        public bool Enable { get; set; }
    }
}
