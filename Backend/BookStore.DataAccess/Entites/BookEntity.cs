using System.ComponentModel.DataAnnotations;

namespace BookStore.DataAccess.Entites;

public class BookEntity
{
    [Key]
    public Guid BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}