using System.ComponentModel.DataAnnotations;

namespace ReservationSystemBackend.Data.DTOs
{
    public class CreateReservationDTO
    {

        [Required]
        public int TopicId { get; set; }

        [Required]
        public int InvestorId { get; set; }
        [Required]
        public int PresenterId { get; set; }
        [Required]
        public int RoomSlotId { get; set; }
    }
}
