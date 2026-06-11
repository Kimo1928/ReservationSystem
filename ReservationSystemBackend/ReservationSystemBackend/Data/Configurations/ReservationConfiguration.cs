using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {


            builder.HasKey(x=>x.Id);

            builder.HasOne(x => x.RoomSlot)
                    .WithOne(x=>x.Reservation)
                    .HasForeignKey<Reservation>(x => x.RoomSlotId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Investor)
                    .WithMany()
                    .HasForeignKey(x => x.InvestorId)   
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Presenter)
                    .WithMany()
                    .HasForeignKey(x => x.PresenterId)
                    .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasOne(x => x.Topic)
                   .WithMany()
                   .HasForeignKey(x => x.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
