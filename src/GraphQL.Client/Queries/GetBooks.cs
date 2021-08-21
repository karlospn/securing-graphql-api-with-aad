namespace Client.WebApi.Queries
{
    public static class GetBooks
    {
        public const string Value =
            @"
            query Get {
                getBooks: books {
                    author
                    title
                    numberOfPages
                    price
                }
            }";
    }
}
