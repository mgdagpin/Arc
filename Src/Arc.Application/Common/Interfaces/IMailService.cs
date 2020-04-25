using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Application.Common.Interfaces
{
    public interface IMailService
    {
        Task SendEmail(string emailAddress, string body);
    }
}
