namespace BookStore.API.Contracts;

public record BooksResponse(
    Guid BookId,
    string Title,
    string Author,
    string Description,
    decimal Price);
    
