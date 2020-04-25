using Arc.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Infrastructure.Identities
{
    public class CurrentUser : ICurrentUser
    {
        public int ID 
        {
            get
            {
                // get it from HttpContext or somewhere
                return 1;
            }
        }
    }
}
