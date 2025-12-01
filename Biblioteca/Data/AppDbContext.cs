using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SingleBook> BookS { get; set; }
        public DbSet<Author> AuthorS { get; set; }
        public DbSet<Genre> GenreS { get; set; }
    }
}
