using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.WebApi.DTO
{
    public class GetBooksData
    {
        [JsonPropertyName("getBooks")]
        public List<Book> Books { get; set; }
    }
}