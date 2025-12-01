using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(Guid id);
        Task CreateAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(Guid id);
    }
}