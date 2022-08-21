using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Shared.Contracts
{
    public interface IUpdateUserContract
    {
        public string Email { get; set; }

        public string Password { get; set; }
        
        public string NewPassword { get; set; }
    }
}
