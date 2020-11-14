using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.Database.Configurations
{
    public class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JokeRating)
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
