using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketAPI.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
