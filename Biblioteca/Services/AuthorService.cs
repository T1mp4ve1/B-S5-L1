using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.AuthorS.ToListAsync();
        }
        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _context.AuthorS.FindAsync(id);
        }
        public async Task CreateAsync(Author author)
        {
            _context.AuthorS.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Author author)
        {
            _context.AuthorS.Update(author);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.AuthorS.FindAsync(id);
            if (entity != null)
            {
                _context.AuthorS.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}