using eLibrary_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace eLibrary_APIs.DataAccess.Repo
{
    public class ItemRepository<T> : IItemRepository<T> where T : BaseEntity, new()
    {
        private readonly ApiDbContext _context;
        private readonly DbSet<T> _db;
        public ItemRepository(ApiDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task AddItem(T item)
        {
            await _db.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(T item)
        {
            _db.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
