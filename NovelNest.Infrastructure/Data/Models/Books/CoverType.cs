namespace NovelNest.Infrastructure.Data.Models.Books
{
    using System.ComponentModel.DataAnnotations;

    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}