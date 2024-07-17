using Microsoft.AspNetCore.Mvc;
using MovieTicketAPI.Data;
using MovieTicketAPI.Models;

namespace MovieTicketAPI.Controllers
{
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        [HttpPost]
        public ActionResult<Ticket> PostTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }
    }
}
