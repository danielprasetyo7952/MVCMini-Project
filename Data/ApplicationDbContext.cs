using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Models;

namespace MVCApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieRent>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(mr => mr.MovieId)
                .IsRequired();

            modelBuilder.Entity<MovieRent>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(mr => mr.CustomerId)
                .IsRequired();
        }

        public DbSet<MVCApplication.Models.Movie> Movie { get; set; } = default!;

        public DbSet<MVCApplication.Models.MovieRent> MovieRent { get; set; } = default!;
    }
}
