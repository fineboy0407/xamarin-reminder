using IdentityServer4.Models;

namespace IdentityServer.Models
{
    public class ErrorViewModel
    {
        public ErrorMessage Error { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}