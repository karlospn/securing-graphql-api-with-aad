using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.WebApi.DTO
{
    public class AddBooksData
    {
        [JsonPropertyName("addBook")]
        public List<Book> Books { get; set; }
    }
}