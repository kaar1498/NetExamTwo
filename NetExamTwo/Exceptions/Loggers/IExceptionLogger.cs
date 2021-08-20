using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NetExamTwo.Exceptions.Loggers
{
    interface IExceptionLogger
    {
        void LogException(Exception exception, string controllerName, ILogger logger);
    }
}
