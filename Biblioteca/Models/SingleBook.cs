using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class SingleBook
    {
        [Key]
        public Guid BookID { get; set; }
        public string? BookName { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }

        // foreign key
        public Guid AuthorID { get; set; }
        public int GenreID { get; set; }

        // navigation
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
    }
}