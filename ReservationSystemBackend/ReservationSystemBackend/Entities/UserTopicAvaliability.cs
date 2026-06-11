namespace ReservationSystemBackend.Entities
{
    public class UserTopicAvaliability
    {

        public int Id { get; set; }
        public int TopicId { get; set; }
        
        public int UserId { get; set; }
        public DateTime AvaliabilityFrom { get; set; }
        public DateTime AvaliabilityTo { get; set; }
        //navigation properties 
        public Topic Topic { get; set; }
        public User User { get; set; }

    }
}
