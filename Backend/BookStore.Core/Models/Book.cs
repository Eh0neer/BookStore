namespace BookStore.Core.Models;

public class Book
{
    public const int MAX_TITLE_LENGHT = 250;
    
    private Book(Guid bookId, string title, string author, string description, decimal price)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Description = description;
        Price = price;
    }
    public Guid BookId { get; }
    public string Title { get; }
    public string Author { get; }
    public string Description { get; }
    public decimal Price { get; }

    public static (Book book, string Error) Create(Guid bookId, string title, string author, string description, decimal price)
    {
        var error = string.Empty;

        if (string.IsNullOrWhiteSpace(title))
        {
            error = "The title must be filled in.";
        }
        else if (title.Length > Book.MAX_TITLE_LENGHT)
        {
            error = $"The title must be less than {Book.MAX_TITLE_LENGHT} characters.";
        }
        else if (string.IsNullOrWhiteSpace(author))
        {
            error = "The author must be filled in.";
        }
        else if (string.IsNullOrWhiteSpace(description))
        {
            error = "The description must be filled in.";
        }
        else if (price <= 0)
        {
            error = "The price must be greater than zero.";
        }

        if (!string.IsNullOrEmpty(error))
        {
            return (null, error);
        }

        var book = new Book(bookId, title, author, description, price);
        return (book, error);
    }
}