using SchoolProject.Data.Entities.Identity;
using SchoolProject.infraStructure.InfrastructureBases;

namespace SchoolProject.infraStructure.Abstracts
{
    public interface IRefreshTokenRepository:IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
