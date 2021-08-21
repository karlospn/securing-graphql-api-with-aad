using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.WebApi.DTO;
using GraphQL.WebApi.GraphQL.Base;
using GraphQL.WebApi.Repository;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace GraphQL.WebApi.GraphQL.Mutations
{
    [GraphQLDescription("Represents the available Book mutations.")]
    [ExtendObjectType(typeof(Mutation))]
    public class BookMutation
    {
        [Authorize]
        public  IEnumerable<Book> AddBooks(
            [Service] IBookRepository repository,
            Book book,
            IResolverContext ctx)
        {
            var errors = ValidateBookDto(book, repository);
            if (errors.Any())
            {
                ErrorReporter.Report(ctx, errors);
                return null;
            }
            return repository.AddBook(book);
        }

        private IEnumerable<string> ValidateBookDto(Book book, 
            IBookRepository repository)
        {
            var errors = new List<string>();

            if (book.NumberOfPages <= 0)
                errors.Add("Book pages cannot be zero or negative");

            if (book.Price <= 0)
                errors.Add("Price cannot be zero or negative");

            if (string.IsNullOrEmpty(book.Author))
                errors.Add("Author cannot be empty");

            if(string.IsNullOrEmpty(book.Title))
                errors.Add("Title cannot be empt.");

            var books = repository.GetBookByAuthor(book.Author);
            if (books.Any(x => string.Equals(x.Title, 
                book.Title, 
                StringComparison.InvariantCultureIgnoreCase)))
            {
                errors.Add("Book already exists");
            }
            
            return errors;
        }
    }
}
