using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class TopicDataSeed
    {
        public static List<Topic> Data => new()
    {
        new Topic { Id = 1, Name = "Finance" },
        new Topic { Id = 2, Name = "IT" },
        new Topic { Id = 3, Name = "Restaurants" },
        new Topic { Id = 4, Name = "Real Estate" },
        new Topic { Id = 5, Name = "Retail" }
    };
    }
}
