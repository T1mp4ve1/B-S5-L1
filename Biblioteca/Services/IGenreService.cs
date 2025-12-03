using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task CreateAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(int id);
    }
}
