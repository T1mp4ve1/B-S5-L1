using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class SingleBook
    {
        [Key]
        public Guid BookID { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string CoverIMG { get; set; }
        [Required]
        public string Description { get; set; }

        // foreign key
        [Required]
        public Guid AuthorID { get; set; }
        [Required]
        public int GenreID { get; set; }

        // navigation
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
    }
}