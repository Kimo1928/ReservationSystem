namespace ReservationSystemBackend.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomSlotId { get; set; }
        public int InvestorId { get; set; }
        public int PresenterId { get; set; }
        public int TopicId { get; set; }


        //navigation Properties
        public User Investor { get; set; }
        public User Presenter { get; set; }
        public Topic Topic { get; set; }
        public RoomSlot RoomSlot { get; set; }


    }
}
