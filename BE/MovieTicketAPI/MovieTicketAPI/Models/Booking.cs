using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ShowId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        public Show Show { get; set; }
    }
}
