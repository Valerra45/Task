using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Domain.Tasks;

namespace Tasks.Api.Infrastructure.Data
{
    public class FakeDataFactory
    {
        public static IEnumerable<TaskType> TaskTypes()
        {
            yield return new TaskType
            {
                Id = Guid.Parse("6E782257-C413-4978-B36C-B95F39AA4E46"),
                Created = DateTime.Now,
                Name = "Type 1"
            };        
            
            yield return new TaskType
            {
                Id = Guid.Parse("3DD1C79D-1188-49FD-8F8A-D16009BB7CF4"),
                Created = DateTime.Now,
                Name = "Type 2"
            };           
            
            yield return new TaskType
            {
                Id = Guid.Parse("0E24FE5E-AFC9-433A-94CF-0ED42DD87B27"),
                Created = DateTime.Now,
                Name = "Type 3"
            };

        }

        public static IEnumerable<Importance> Importances()
        {
            yield return new Importance
            {
                Id = Guid.Parse("0E2B1B9B-1CDE-4868-ADFC-AFCFABC758B0"),
                Created = DateTime.Now,
                Name = "Importance 1"
            };       
            
            yield return new Importance
            {
                Id = Guid.Parse("B831DC3A-AEF5-4E21-97E1-F1FF5DD72093"),
                Created = DateTime.Now,
                Name = "Importance 2"
            };
        }
    }
}
