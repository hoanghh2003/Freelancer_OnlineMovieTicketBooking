using System.ComponentModel.DataAnnotations;

namespace MovieTicketAPI.DTOs
{
    public class BookingCreateDto
    {
        [Required]
        public int ShowId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }
    }
}
