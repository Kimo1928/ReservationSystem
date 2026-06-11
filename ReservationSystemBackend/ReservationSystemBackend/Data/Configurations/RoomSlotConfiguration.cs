using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Data.DataSeed;
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.Configurations
{
    public class RoomSlotConfiguration : IEntityTypeConfiguration<RoomSlot>

    {
        public void Configure(EntityTypeBuilder<RoomSlot> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Room)
                .WithMany(x=>x.RoomSlots)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.StartTime)
                .IsRequired();
            builder.HasData(RoomSlotDataSeed.Data);

        }
    }
}