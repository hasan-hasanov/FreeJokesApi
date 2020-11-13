using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.Database.Configurations
{
    public class JokeConfig : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Jokes);

            builder.HasMany(x => x.JokeFlags)
                .WithOne(x => x.Joke)
                .IsRequired(false);

            builder.HasMany(x => x.JokeParts)
                .WithOne(x => x.Joke);

            builder.HasMany(x => x.JokeRatings)
                .WithOne(x => x.Joke)
                .IsRequired(false);
        }
    }
}
