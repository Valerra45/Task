using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Core.Domain.Tasks
{
    public class TaskProduct : BaseEntity
    {
        public virtual Product? Product { get; set; }

        public virtual DocumentTask? DocumentTask { get; set; }

        public decimal Discount { get; set; }
       
        public decimal Margin { get; set; }

        public bool Enable { get; set; }
    }
}
