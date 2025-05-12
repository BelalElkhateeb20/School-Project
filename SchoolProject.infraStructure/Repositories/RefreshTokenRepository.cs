using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.infraStructure.Abstracts;
using SchoolProject.infraStructure.Data;
using SchoolProject.infraStructure.InfrastructureBases;

namespace SchoolProject.infraStructure.Repositories
{
    public class RefreshTokenRepository(ApplicationDBContext context):GenericRepositoryAsync<UserRefreshToken>(context) , IRefreshTokenRepository
    {
        private readonly DbSet<UserRefreshToken>  _userRefreshTokens = context.Set<UserRefreshToken>();
    }
}
