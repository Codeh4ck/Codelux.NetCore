using System;

namespace Codelux.NetCore.Common.Requests
{
    public abstract class Request
    {
        protected Request()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid CallerRequestId { get; set; }
    }
}
