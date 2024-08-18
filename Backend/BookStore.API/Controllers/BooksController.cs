using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BooksResponse>>> GetBooks()
    {
        var books = await _booksService.GetAllBooks();
        
        var response = books.Select(b => new BooksResponse(b.BookId, b.Title, b.Author, b.Description, b.Price)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Author,
            request.Description,
            request.Price);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var bookId = await _booksService.CreateBook(book);
        
        return Ok(bookId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid BookId, [FromBody] BooksRequest request)
    {
        var bookId = await _booksService.UpdateBook(BookId, request.Title, request.Author, request.Price, request.Description);
        return Ok(bookId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid BookId)
    {
        var bookId = await _booksService.DeleteBook(BookId);
        return Ok(bookId);
    }
    
}