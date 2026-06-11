using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class UserDataSeed
    {
        public static List<User> Data => new()
    {
        new User
        {
            Id = 1,
            Name = "Admin",
            Mobile = "01000000000",
            UserType = (UserTypes)1
        },

        new User
        {
            Id = 2,
            Name = "CIB",
            Mobile = "01011111111",
            UserType = (UserTypes)2
        },

        new User
        {
            Id = 3,
            Name = "EFG Hermes",
            Mobile = "01022222222",
            UserType = (UserTypes)2
        },

        new User
        {
            Id = 4,
            Name = "Oltob",
            Mobile = "01033333333",
            UserType = (UserTypes)3
        },

        new User
        {
            Id = 5,
            Name = "Tech Solutions",
            Mobile = "01044444444",
            UserType = (UserTypes)3
        }
    };
    }
}
