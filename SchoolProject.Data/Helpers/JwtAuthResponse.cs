
namespace SchoolProject.Data.Helpers
{
    public class JwtAuthRespone
    {
        public string AccessToken { get; set; }
        public RefreshToken  RefreshToken { get; set; }

    }
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string RefreshTokenstring { get; set; }
        public DateTime ExpireAt { get; set; }
    }

}
