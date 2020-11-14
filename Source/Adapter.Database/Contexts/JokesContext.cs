using Adapter.Database.Configurations;
using Adapter.Database.Contexts.Seed;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Contexts
{
    public class JokesContext : DbContext
    {
        public JokesContext(DbContextOptions<JokesContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Flag> Flags { get; set; }

        public DbSet<Joke> Jokes { get; set; }

        public DbSet<JokeFlag> JokeFlags { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new FlagConfig());
            modelBuilder.ApplyConfiguration(new JokeConfig());
            modelBuilder.ApplyConfiguration(new JokeFlagConfig());
            modelBuilder.ApplyConfiguration(new PartConfig());
            modelBuilder.ApplyConfiguration(new RatingConfig());

            modelBuilder.Entity<Category>().HasData(new CategorySeeds().Categories);
            modelBuilder.Entity<Flag>().HasData(new FlagSeeds().Flags);
        }
    }
}
