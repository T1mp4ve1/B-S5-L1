using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ISingleBookService
    {
        Task<List<SingleBook>> GetAllAsync();
        Task<SingleBook> GetByIdAsync(Guid id);
        Task CreateAsync(SingleBook book);
        Task UpdateAsync(SingleBook book);
        Task DeleteAsync(Guid id);
    }
}
