using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;

namespace MVCApplication.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Movie Seeder
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        Genre = "Romantic",
                        Price = 50000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        Genre = "Comedy",
                        Price = 57000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        Genre = "Comedy",
                        Price = 30000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        Genre = "Western",
                        Price = 75000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        Genre = "Action",
                        Price = 100000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Dark Knight Rises",
                        Genre = "Action",
                        Price = 120000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Avanger: Civil War",
                        Genre = "Action",
                        Price = 130000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Avanger: Infinity War",
                        Genre = "Action",
                        Price = 150000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "Avanger: Endgame",
                        Genre = "Action",
                        Price = 200000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        Genre = "Drama",
                        Price = 90000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        Genre = "Drama",
                        Price = 80000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Godfather: Part II",
                        Genre = "Drama",
                        Price = 85000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Godfather: Part III",
                        Genre = "Drama",
                        Price = 75000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        Genre = "Fantasy",
                        Price = 110000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Two Towers",
                        Genre = "Fantasy",
                        Price = 115000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        Genre = "Fantasy",
                        Price = 120000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Hobbit: An Unexpected Journey",
                        Genre = "Fantasy",
                        Price = 100000,
                        IsRented = false
                    },
                    new Movie
                    {
                        Title = "The Hobbit: The Desolation of Smaug",
                        Genre = "Fantasy",
                        Price = 105000,
                        IsRented = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
