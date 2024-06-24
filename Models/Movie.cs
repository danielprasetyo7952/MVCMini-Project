using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Price { get; set; } = 0;
        [NotMapped]
        public IFormFile? PosterImage { get; set; }
        [Display(Name = "Poster")]
        public string? PosterPath { get; set; }
        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; } = false;
    }
}
