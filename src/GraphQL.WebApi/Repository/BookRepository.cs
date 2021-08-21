using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.WebApi.DTO;

namespace GraphQL.WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book> Books = new();

        public BookRepository()
        {
            SeedBooks();
        }

        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return Books.Where(x =>
                string.Equals(
                    x.Author, 
                    author, 
                    StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Book> AddBook(Book book)
        {
            Books.Add(book);
            return Books;
        }

        private void SeedBooks()
        {
            Books.Add(new Book
            {
                Author = "Jon Bodner",
                NumberOfPages = 300,
                Price = 32.50,
                Title = "Learning Go"
            });

            Books.Add(new Book
            {
                Author = "Eric Matthes",
                NumberOfPages = 544,
                Price = 25.00,
                Title = "Python Crash Course"
            });

            Books.Add(new Book
            {
                Author = "Robert C Martin",
                NumberOfPages = 432,
                Price = 18.50,
                Title = "Clean Architecture"
            });
        }
    }
}
