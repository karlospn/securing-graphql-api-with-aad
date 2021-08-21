using System.Collections.Generic;
using GraphQL.WebApi.DTO;
using GraphQL.WebApi.GraphQL.Base;
using GraphQL.WebApi.Repository;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;

namespace GraphQL.WebApi.GraphQL.Querys
{
    [GraphQLDescription("Represents the available Book queries.")]
    [ExtendObjectType(typeof(Query))]
    public class BookQuery
    {
        [Authorize]
        public  IEnumerable<Book> GetBooks(
            [Service] IBookRepository repository)
        {
            return repository.GetBooks();
        }

        [Authorize]
        public IEnumerable<Book> GetBooksByAuthor(
            [Service] IBookRepository repository,
            string author)
        {
            return repository.GetBookByAuthor(author);
        }
    }
}
