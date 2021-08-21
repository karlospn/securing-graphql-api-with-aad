using GraphQL.WebApi.DTO;
using HotChocolate.Types;

namespace GraphQL.WebApi.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Represents a book entity.");

            descriptor
                .Field(c => c.Author)
                .Description("The author of the book.");

            descriptor
                .Field(c => c.Title)
                .Description("The title of the book.");

            descriptor
                .Field(c => c.Price)
                .Description("Book price on Euros.");

            descriptor
                .Field(c => c.NumberOfPages)
                .Description("How many pages the book has.");

            base.Configure(descriptor);
        }
    }
}
