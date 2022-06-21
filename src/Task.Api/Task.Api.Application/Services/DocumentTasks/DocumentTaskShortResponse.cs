using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.Importances;
using Tasks.Api.Application.Services.Partners;
using Tasks.Api.Application.Services.TaskTypes;

namespace Tasks.Api.Application.Services.DocumentTasks
{
    public class DocumentTaskShortResponse
    {      
        public Guid Id { get; set; }
        
        public string? Name { get; set; }
       
        public int Priority { get; set; }
        
        public PartnerResponse? Partner { get; set; }   
       
        public TaskTypeResponse? TaskType { get; set; }
       
        public ImportanceResponse? Importance { get; set; }
        
        public DateTime? DateStart { get; set; }
    }
}
