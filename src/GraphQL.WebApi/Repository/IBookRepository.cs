using System.Collections.Generic;
using GraphQL.WebApi.DTO;

namespace GraphQL.WebApi.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBookByAuthor(string author);
        IEnumerable<Book> AddBook(Book book);
    }
}