namespace Client.WebApi.Queries
{
    public static class GetBooksByAuthor
    {
        public const string Value =
            @"
            query GetByAuthor ($author: String!) {
                getBooksByAuthor: booksByAuthor(author: $author) {
                    author
                    title
                    numberOfPages
                    price
                }
            }";
    }
}
