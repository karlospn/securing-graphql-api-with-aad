namespace Client.WebApi.Queries
{
    public static class AddBook
    {
        public const string Value =
            @"
            mutation AddBook ($author: String!, $pages: Int!, $price: Float!, $title: String!) {
                addBook: addBooks(book: {author: $author, numberOfPages: $pages, price: $price, title: $title}) {
                    author
                    title
                    numberOfPages
                    price
                }
            }";
    }
}
