using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.infraStructure.Data;

namespace SchoolProject.infraStructure.InfrastructureBases
{
    public class GenericRepositoryAsync<T>(ApplicationDBContext context) : IGenericRepositoryAsync<T> where T : class
    {
        protected readonly ApplicationDBContext _context = context;

        public async Task<T> AddAsync(T entity)
        {
            var item = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return item.Entity;
        }

        public async Task AddRangeAsync(ICollection<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction(); //if any of the Proccess feild Move Back and cancel All Proccesies
        }

        public void Commit()
        {
           _context.Database.CommitTransaction();
        }

        public async Task DeleteAsync(T entity)
        {
             _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)//
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetStudentByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _context.Set<T>().AsQueryable();
        }

        public  IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
