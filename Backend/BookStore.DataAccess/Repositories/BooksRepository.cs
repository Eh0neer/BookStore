using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly BookStoreDbContext _context;

    public BooksRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> Get()
    {
        var bookEntites = await _context.Books
            .AsNoTracking()
            .ToListAsync();

        var books = bookEntites
            .Select(b => Book.Create(b.BookId, b.Title, b.Description, b.Author, b.Price).book)
            .ToList();
        
        return books;
    }

    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            BookId = book.BookId,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Price = book.Price
        };
        
        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();
        
        return bookEntity.BookId;
    }
    

    public async Task<Guid> Update(Guid bookId, string title, string author, string description, decimal price)
    {
        _context.Books
            .Where(b => b.BookId == bookId)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Author, b => author)
                .SetProperty(b => b.Price, b => price));
        return bookId;
    }

    public async Task<Guid> Delete(Guid bookId)
    {
        await _context.Books
            .Where(b => b.BookId == bookId)
            .ExecuteDeleteAsync();
        return bookId;
    }
    
}