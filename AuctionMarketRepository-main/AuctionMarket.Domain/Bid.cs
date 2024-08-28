public class Bid
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}
