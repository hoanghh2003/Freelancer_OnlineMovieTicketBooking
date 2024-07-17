namespace MovieTicketAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string BuyerName { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

}
