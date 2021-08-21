using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.WebApi.DTO
{
    public class GetBooksData
    {
        [JsonPropertyName("getBooks")]
        public List<Book> Books { get; set; }
    }

    public class GetBooksByAuthorData
    {
        [JsonPropertyName("getBooksbyAuthor")]
        public List<Book> Books { get; set; }
    }


    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int NumberOfPages { get; set; }
    }
}
