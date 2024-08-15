using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;

namespace ServerLibrary.Repositories
{
    public class SQLRepository<T> : ISQLRepository<T> where T : BaseEntity
    {
        readonly HotelDbContext _context;
        public SQLRepository(HotelDbContext appContext)
        {
            _context = appContext;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(w => w.Id == id);
        }

        public async Task<T> CreateAsync(T item)
        {
            try
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error + {ex}");
            }
            return item;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                _context.Update(item);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error + {ex}");
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = _context.Set<T>().SingleOrDefault(w => w.Id == id);
                if (item is not null)
                {
                    _context.Remove(item);
                    var result = await _context.SaveChangesAsync();
                    return result > 0;
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error + {ex}");
            }
            return false;
        }
    }
}

