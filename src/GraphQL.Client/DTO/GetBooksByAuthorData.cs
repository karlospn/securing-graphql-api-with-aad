using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.WebApi.DTO
{
    public class GetBooksByAuthorData
    {
        [JsonPropertyName("getBooksbyAuthor")]
        public List<Book> Books { get; set; }
    }
}