using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBooksService
{
    Task<List<Book>> GetAllBooks();
    Task<Guid> CreateBook(Book book);
    Task<Guid> UpdateBook(Guid BookId, string Title, string Author, decimal Price, string Description);
    Task<Guid> DeleteBook(Guid BookId);
}