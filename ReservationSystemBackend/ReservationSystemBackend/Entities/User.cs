namespace ReservationSystemBackend.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
        public UserTypes UserType { get; set; }

        //navigation property
        public ICollection<UserTopicAvaliability> UserTopicAvaliabilities { get; set; } = [];


    }
}
