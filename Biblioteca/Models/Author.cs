using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorID { get; set; } = Guid.NewGuid();
        public string? Pseudonym { get; set; }

        public ICollection<SingleBook> Books { get; set; } = new List<SingleBook>();
    }
}