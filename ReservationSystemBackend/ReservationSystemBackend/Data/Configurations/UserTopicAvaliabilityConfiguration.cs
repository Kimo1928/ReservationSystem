using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Data.DataSeed;


namespace ReservationSystemBackend.Data.Configurations
{
    public class UserTopicAvaliabilityConfiguration : IEntityTypeConfiguration<UserTopicAvaliability>

    {
        public void Configure(EntityTypeBuilder<UserTopicAvaliability> builder) { 
          builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                  .WithMany(x=>x.UserTopicAvaliabilities)
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Topic)
                   .WithMany()
                   .HasForeignKey(x => x.TopicId);
            builder.Property(x => x.AvaliabilityFrom)
                .IsRequired();
            builder.Property(x => x.AvaliabilityTo)
                .IsRequired();

           

            builder.HasData(UserAvaliabilityDataSeed.Data);

        }
    }
}
