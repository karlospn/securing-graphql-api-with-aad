using System.ComponentModel.DataAnnotations;

namespace Client.WebApi.DTO
{
    public class Book
    {
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int NumberOfPages { get; set; }
    }
}
