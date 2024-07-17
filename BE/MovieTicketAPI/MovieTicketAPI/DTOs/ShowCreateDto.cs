using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketAPI.DTOs
{
    public class ShowCreateDto
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
