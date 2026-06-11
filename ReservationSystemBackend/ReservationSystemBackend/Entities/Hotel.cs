using System.ComponentModel.DataAnnotations;

namespace ReservationSystemBackend.Entities
{
    public class Hotel
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        //navigation property
        public ICollection<Room> Rooms { get; set; } = [];
    }
}
