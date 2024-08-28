public interface IBidRepository
{
    Task<IEnumerable<Bid>> GetBidsByRoomIdAsync(int roomId);
    Task AddBidAsync(Bid bid);
}
