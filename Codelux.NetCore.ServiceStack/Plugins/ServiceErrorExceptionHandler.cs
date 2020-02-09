using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServiceStack.Web;
using ServiceStack.Validation;
using Codelux.NetCore.Common.Extensions;
using Codelux.NetCore.Common.Models;
using Codelux.NetCore.Common.Responses;

namespace Codelux.NetCore.ServiceStack.Plugins
{
    public class ServiceErrorExceptionHandler
    {
        private readonly string _serviceName;

        public ServiceErrorExceptionHandler(string serviceName)
        {
            _serviceName = serviceName;
        }

        public ServiceResponse Handle(IRequest httpReq, object obj, Exception exception)
        {
            if (exception is ServiceErrorException apiErrorException)
            {
                httpReq.Response.StatusCode = (int)apiErrorException.StatusCode;

                if (apiErrorException.InnerException == null)
                    return new ServiceErrorResponse(apiErrorException.Service, apiErrorException.Index, apiErrorException.Message);

                List<string> exceptionMessages = apiErrorException.GetInnerExceptionMessages();

                return new ServiceErrorResponse(apiErrorException.Service, apiErrorException.Index, apiErrorException.Message, exceptionMessages);
            }

            if (exception is NotImplementedException)
            {
                httpReq.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                return new ServiceErrorResponse(_serviceName, ServiceCodes.INTERNAL_SERVER_ERROR, "Not Implemented");
            }

            if (exception is TaskCanceledException)
            {
                httpReq.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new ServiceErrorResponse(_serviceName, ServiceCodes.INTERNAL_SERVER_ERROR, OverridenExceptionMessages.TASK_CANCELED_EXCEPTION_MESSAGE);
            }

            if (exception is ValidationError validationError)
            {
                httpReq.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                ServiceValidationResponse validationResponse = new ServiceValidationResponse(_serviceName);
                foreach (var violation in validationError.Violations)
                {
                    var apiValidationError = new ServiceValidationError(violation.FieldName, violation.ErrorMessage);
                    validationResponse.ValidationErrors.Add(apiValidationError);
                }
                return validationResponse;
            }

            httpReq.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return new ServiceErrorResponse(_serviceName, ServiceCodes.INTERNAL_SERVER_ERROR, exception.Message);
        }
    }
}
