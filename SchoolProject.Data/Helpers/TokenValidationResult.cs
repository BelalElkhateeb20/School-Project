using System.Security.Claims;

namespace SchoolProject.Data.Helpers
{
    public class TokenValidatedResult
    {
        public bool IsValid { get; set; }
        public bool IsExpired { get; set; }
        public string Message { get; set; }
        public ClaimsPrincipal? Principal { get; set; }
    }
}
