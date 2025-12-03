using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class GenreService : IGenreService
    {
        //DI
        private readonly AppDbContext _context;

        public GenreService(AppDbContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task CreateAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }

        //READ
        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.GenreS
                .OrderBy(g => g.GenreName)
                .ToListAsync();
        }

        //READ: ID
        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.GenreS.FindAsync(id);
        }

        //UPDATE
        public async Task UpdateAsync(Genre genre)
        {
            _context.GenreS.Update(genre);
            await _context.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.GenreS.FindAsync(id);
            if (entity != null)
            {
                _context.GenreS.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
