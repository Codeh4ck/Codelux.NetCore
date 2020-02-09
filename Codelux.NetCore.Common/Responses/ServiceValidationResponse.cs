using System.Collections.Generic;
using Codelux.NetCore.Common.Models;

namespace Codelux.NetCore.Common.Responses
{
    public class ServiceValidationResponse : ServiceResponse
    {
        public ServiceValidationResponse() : base(string.Empty, ServiceCodes.VALIDATION_ERROR)
        {
            ValidationErrors = new List<ServiceValidationError>();
        }

        public ServiceValidationResponse(string service) : base(service, ServiceCodes.VALIDATION_ERROR)
        {
            ValidationErrors = new List<ServiceValidationError>();
        }

        public List<ServiceValidationError> ValidationErrors { get; }
    }
}
