using Adapter.Database.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Contexts
{
    public class FreeJokesContext : DbContext
    {
        public FreeJokesContext(DbContextOptions<FreeJokesContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Flag> Flags { get; set; }

        public DbSet<Joke> Jokes { get; set; }

        public DbSet<JokeFlag> JokeFlags { get; set; }

        public DbSet<JokePart> JokeParts { get; set; }

        public DbSet<JokeRating> JokeRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new FlagConfig());
            modelBuilder.ApplyConfiguration(new JokeConfig());
            modelBuilder.ApplyConfiguration(new JokeFlagConfig());
            modelBuilder.ApplyConfiguration(new JokePartConfig());
            modelBuilder.ApplyConfiguration(new JokeRatingConfig());
        }
    }
}
