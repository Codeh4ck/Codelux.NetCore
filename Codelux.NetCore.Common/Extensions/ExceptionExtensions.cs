using System;
using System.Collections.Generic;

namespace Codelux.NetCore.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static List<string> GetAllExceptionMessages(this Exception exception)
        {
            if (exception == null) return null;
            List<string> exceptionMessages = new List<string> { exception.Message };

            List<string> innerMessages = exception.GetInnerExceptionMessages();
            if (innerMessages != null) exceptionMessages.AddRange(innerMessages);

            return exceptionMessages;
        }

        public static List<string> GetInnerExceptionMessages(this Exception exception)
        {
            if (exception.InnerException == null) return null;

            List<string> exceptionMessages = new List<string>();

            Exception current = exception.InnerException;
            exceptionMessages.Add(current.Message);

            while (current.InnerException != null)
            {
                current = current.InnerException;
                exceptionMessages.Add(current.Message);
            }

            return exceptionMessages;
        }
        public static List<Exception> GetAllInnerExceptions(this Exception exception)
        {
            if (exception.InnerException == null) return null;

            List<Exception> exceptions = new List<Exception>();

            Exception current = exception.InnerException;
            exceptions.Add(current);

            while (current.InnerException != null)
            {
                current = current.InnerException;
                exceptions.Add(current);
            }

            return exceptions;
        }
    }
}
