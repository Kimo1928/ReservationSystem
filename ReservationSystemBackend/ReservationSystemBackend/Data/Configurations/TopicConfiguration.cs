using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Data.DataSeed;
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {

        public void Configure(EntityTypeBuilder<Topic> builder) {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.HasData(TopicDataSeed.Data);
        }
    }
}
