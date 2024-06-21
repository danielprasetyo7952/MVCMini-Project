using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;

namespace MVCApplication.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
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
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
