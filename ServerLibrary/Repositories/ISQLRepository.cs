using BaseLibrary.Entities;

namespace ServerLibrary.Repositories
{
    public interface ISQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> CreateAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
