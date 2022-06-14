using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Api.Application.Services.Importances
{
    public class ImportanceCreateOrEdit
    {
        public Guid UtId { get; set; }

        public string? Name { get; set; }
    }
}
