namespace ReservationSystemBackend.Entities
{
    public class Room
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }

        //navigation Properties

        public Hotel Hotel { get; set; }

        public ICollection<RoomSlot> RoomSlots { get; set; } = [];
    }
}
