using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBooksRepository
{
    Task<Guid> Create(Book book);
    Task<Guid> Update(Guid bookId, string title, string author, string description, decimal price);
    Task<Guid> Delete(Guid bookId);
    Task<List<Book>> Get();
}