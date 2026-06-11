using ReservationSystemBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystemBackend.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }

        [Required]
        public int UserType { get; set; }
        public List<UserTopicAvaliabilityDTO> UserTopicAvaliabilityDTOs { get; set; } = new();
    }

    public class PresenterMatchDTO {

        public int UserId { get; set; }
       
        public string Name { get; set; }
        public string Mobile { get; set; }


        public DateTime OverlapFrom { get; set; }

        public DateTime OverlapTo { get; set; }
    }

    public class UserTopicAvaliabilityDTO { 
        [Required]

        public int TopicId { get; set; }

        [Required]
        public DateTime AvaliabilityFrom { get; set; }
        [Required]

        public DateTime AvaliabilityTo { get; set; }
    }

    public class UserDTO { 
        public int Id { get; set; }
        public string Name { get; set; }

        public string Mobile { get; set; }

        public List<UserTopicAvaliabilityDTO> UserTopicAvaliabilityDTOs { get; set; } = new();



    }


}
