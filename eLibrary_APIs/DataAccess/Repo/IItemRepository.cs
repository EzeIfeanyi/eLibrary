using eLibrary_APIs.Models;

namespace eLibrary_APIs.DataAccess.Repo
{
    public interface IItemRepository<T> where T : BaseEntity, new()
    {
        Task AddItem(T item);
        Task DeleteItem(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateItem(T item);
    }
}