using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.Database.Configurations
{
    public class JokeRatingConfig : IEntityTypeConfiguration<JokeRating>
    {
        public void Configure(EntityTypeBuilder<JokeRating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.JokeId)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

            builder.HasOne(x => x.Joke)
                .WithMany(x => x.JokeRatings);
        }
    }
}
