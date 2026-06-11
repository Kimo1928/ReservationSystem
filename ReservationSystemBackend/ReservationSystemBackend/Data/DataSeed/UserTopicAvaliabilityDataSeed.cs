
using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class UserAvaliabilityDataSeed
    {
        public static List<UserTopicAvaliability> Data => new()
        {
            // CIB
        new UserTopicAvaliability
        {
            Id = 1,
            UserId = 2,
            TopicId = 1,
            AvaliabilityFrom = new DateTime(2026, 6, 1, 10, 0, 0),
            AvaliabilityTo = new DateTime(2026, 6, 1, 13, 0, 0)
        },

        new UserTopicAvaliability
        {
            Id = 2,
            UserId = 2,
            TopicId = 3,
            AvaliabilityFrom = new DateTime(2026, 6, 1, 13, 0, 0),
            AvaliabilityTo = new DateTime(2026, 6, 1, 16, 0, 0)
        },

            // EFG
        new UserTopicAvaliability
        {
            Id = 3,
            UserId = 3,
            TopicId = 2,
            AvaliabilityFrom = new DateTime(2026, 6, 1, 9, 0, 0),
            AvaliabilityTo = new DateTime(2026, 6, 1, 12, 0, 0)
        },

            // Oltob
        new UserTopicAvaliability
        {
            Id = 4,
            UserId = 4,
            TopicId = 3,
            AvaliabilityFrom = new DateTime(2026, 6, 1, 8, 0, 0),
            AvaliabilityTo = new DateTime(2026, 6, 1, 16, 0, 0)
        },

            // Tech Solutions
        new UserTopicAvaliability
        {
            Id = 5,
            UserId = 5,
            TopicId = 2,
            AvaliabilityFrom = new DateTime(2026, 6, 1, 10, 0, 0),
            AvaliabilityTo = new DateTime(2026, 6, 1, 15, 0, 0)
        }
    };
    }
}
