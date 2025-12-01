using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string? GenreName { get; set; }

        public ICollection<SingleBook> Books { get; set; } = new List<SingleBook>();
    }
}