using Microsoft.EntityFrameworkCore;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Infrastructure.Context;

namespace RateMyAnimal.Infrastructure.Repository
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        private readonly AppDbContext _context;
        public AnimalRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Animal> GetByIdInclude(int id)
        {
            var query = await _context.Animals
                .Include(x => x.AnimalCategories)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return query;
        }

        public async Task<IEnumerable<Animal>> GetAllInclude(int? recordsNumber)
        {
            var query = await _context.Animals
                .Include(x => x.AnimalCategories).ThenInclude(x => x.Category)
                .OrderByDescending(x => x.Date)
                .AsNoTracking().ToListAsync();

            if (recordsNumber != null)
                return query.Take((int)recordsNumber);
            else
                return query;
        }

        public async Task<IEnumerable<Animal>> GetAllByIdCategory(int id)
        {
            var query = await _context.Animals 
                .Include(x => x.AnimalCategories).ThenInclude(x => x.Category)
                .Where(x => x.AnimalCategories.Any(x => x.CategoryId == id))
                .OrderByDescending(x => x.Date)
                .AsNoTracking().ToListAsync();

            return query;
        }
    }
}
