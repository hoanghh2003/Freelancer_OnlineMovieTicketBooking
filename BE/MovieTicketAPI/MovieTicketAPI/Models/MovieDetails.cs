using System;
using System.Collections.Generic;

namespace MovieTicketAPI.Models
{
    public class MovieDetails : Movie
    {
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public List<string> Actors { get; set; }
        public string Rated { get; set; }
    }
}
