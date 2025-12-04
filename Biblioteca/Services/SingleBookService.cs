using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class SingleBookService : ISingleBookService
    {
        private readonly AppDbContext _db;

        public SingleBookService(AppDbContext db)
        {
            _db = db;
        }

        //CREATE
        public async Task CreateAsync(SingleBook book)
        {
            _db.BookS.Add(book);
            await _db.SaveChangesAsync();
        }

        //READ: ALL
        public async Task<List<SingleBook>> GetAllAsync()
        {
            return await _db.BookS
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .OrderBy(b => b.BookName)
                .ToListAsync();
        }

        //READ: ID
        public async Task<SingleBook?> GetByIdAsync(Guid id)
        {
            return await _db.BookS.FindAsync(id);
        }

        //UPDATE
        public async Task UpdateAsync(SingleBook book)
        {
            _db.BookS.Update(book);
            await _db.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.BookS.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

        }
    }
}
