using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Data.DataSeed;
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Hotel)
               .WithMany(x => x.Rooms)
               .HasForeignKey(x => x.HotelId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(RoomDataSeed.Data);


        }
    }
}