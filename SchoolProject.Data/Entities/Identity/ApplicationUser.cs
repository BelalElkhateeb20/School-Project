using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.EncryptColumn.Attribute;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Data.Enums;
namespace SchoolProject.Data.Entities.Identity
{
    public class User:IdentityUser<int>
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        [InverseProperty("User")]
        public UserType UserType { get; set; }
        public Student Student { get; set; }
        [InverseProperty("User")]
        public Instructor Instructor { get; set; }
        public bool? Supervisor { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        [EncryptColumn]
        public string Code { get; set; }
        [InverseProperty(nameof(UserRefreshToken.user))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
