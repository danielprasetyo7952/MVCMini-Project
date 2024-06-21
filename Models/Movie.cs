using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Price { get; set; } = 0;
        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; } = false;
    }
}
