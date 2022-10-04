using Microsoft.EntityFrameworkCore;
using RateMyAnimal.Infrastructure.Context;
using RateMyAnimal.Domain.Interfaces;

namespace RateMyAnimal.Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task Add(T entity)
        {
            _db.Add(entity);
            await SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _db.Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
