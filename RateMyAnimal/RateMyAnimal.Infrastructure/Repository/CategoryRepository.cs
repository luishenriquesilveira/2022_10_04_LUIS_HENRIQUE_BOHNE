using Microsoft.EntityFrameworkCore;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Infrastructure.Context;

namespace RateMyAnimal.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Category> GetByIdInclude(int id)
        {
            var query = await _context.Categories
                .Include(x => x.AnimalCategories)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Category>> GetAllInclude(int? recordsNumber)
        {
            var query = await _context.Categories
                .Include(x => x.AnimalCategories)
                .OrderByDescending(x => x.AnimalCategories.Count())
                .AsNoTracking().ToListAsync();

            if (recordsNumber != null)
                return query.Take((int)recordsNumber);
            else
                return query;
        }
    }
}
