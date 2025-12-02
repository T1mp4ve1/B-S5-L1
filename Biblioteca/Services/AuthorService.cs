using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class AuthorService : IAuthorService
    {
        //DI
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        //ALL
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.AuthorS
                .OrderBy(a => a.Pseudonym)
                .ToListAsync();
        }

        //BY ID
        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _context.AuthorS.FindAsync(id);
        }

        //CREATE
        public async Task CreateAsync(Author author)
        {
            _context.AuthorS.Add(author);
            await _context.SaveChangesAsync();
        }

        //UPDATE
        public async Task UpdateAsync(Author author)
        {
            _context.AuthorS.Update(author);
            await _context.SaveChangesAsync();
        }

        //DELETE
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