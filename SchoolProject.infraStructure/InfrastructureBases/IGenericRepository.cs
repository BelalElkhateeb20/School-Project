using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolProject.infraStructure.InfrastructureBases
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetStudentByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
