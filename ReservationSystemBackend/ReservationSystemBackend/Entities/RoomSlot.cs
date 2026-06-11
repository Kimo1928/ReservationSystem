namespace ReservationSystemBackend.Entities
{
    public class RoomSlot
    {

        public int Id { get; set; }

        public int RoomId { get; set; }

        public DateTime StartTime { get; set; }

        public Room Room { get; set; }

        public Reservation Reservation { get; set; }
    }
}
