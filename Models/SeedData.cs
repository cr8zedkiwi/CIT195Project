using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Fallout 4",
                    ReleaseDate = DateTime.Parse("2015-11-10"),
                    Genre = "Single Player",
                    Price = 19.99M,
                    Rating="M"
                },

                new Movie
                {
                    Title = "Counter-Strike 2",
                    ReleaseDate = DateTime.Parse("2012-8-21"),
                    Genre = "Multiplayer",
                    Price = 14.99M,
                    Rating = "M"
                },

                new Movie
                {
                    Title = "Dead Island 2",
                    ReleaseDate = DateTime.Parse("2024-4-22"),
                    Genre = "CO-OP",
                    Price = 59.99M,
                    Rating = "M"
                },

                new Movie
                {
                    Title = "Dead By Daylight",
                    ReleaseDate = DateTime.Parse("2016-6-14"),
                    Genre = "Multiplayer",
                    Price = 19.99M,
                    Rating = "M"
                }
            );
            context.SaveChanges();
        }
    }
}