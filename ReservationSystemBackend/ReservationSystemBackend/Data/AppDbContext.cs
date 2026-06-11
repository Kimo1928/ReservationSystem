using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {

       public DbSet<User> Users { get; set; }
       public DbSet<UserTopicAvaliability> UserTopicAvaliabilities { get; set; }
       public DbSet<Topic> Topics { get; set; }
       public DbSet<Hotel> Hotels { get; set; }
       public DbSet<Room> Rooms { get; set; }
       public DbSet<RoomSlot> RoomSlots { get; set; }
       public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }


    }
}
