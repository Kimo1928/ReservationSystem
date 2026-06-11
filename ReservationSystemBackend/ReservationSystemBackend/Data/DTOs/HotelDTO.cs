using ReservationSystemBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystemBackend.Data.DTOs
{
   

    public class CreateHotelDTO {

        [Required]
        public string Name { get; set; }
        public ICollection<RoomDTO> Rooms { get; set; }

    }

    public class RoomDTO { 
        public string Name { get; set; }
        public ICollection<RoomSlotDTO> RoomSlots { get; set; }
    }

    public class RoomSlotDTO { 
        public DateTime StartTime { get; set; }
    }


    public class RoomSlotDetailsDTO { 

    public int RoomSlotId { get; set; }
    
    public string HotelName { get; set; }
    public string RoomName { get; set; }
    
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
    
    }

    public class HotelDTO { 
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomDTO> Rooms { get; set; }
    }
}
