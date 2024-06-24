using Microsoft.AspNetCore.Identity;

namespace MVCApplication.Models
{
    public class MovieRent
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int CustomerId { get; set; }
        public IdentityUser Customer { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; } 
    }
}
