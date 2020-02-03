using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception InnermostException(this Exception exception)
        {
            if (exception.InnerException != null)
            {
                return InnermostException(exception.InnerException);
            }

            return exception;
        }
    }
}
