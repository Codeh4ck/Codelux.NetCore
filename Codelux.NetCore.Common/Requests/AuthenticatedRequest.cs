using System;

namespace Codelux.NetCore.Common.Requests
{
    public class AuthenticatedRequest : Request
    {
        public Guid UserId { get; set; }
        public Guid AuthToken { get; set; }
        public Guid ProductId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
