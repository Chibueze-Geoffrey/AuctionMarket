using AuctionMarket.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class BidRepository : IBidRepository
{
    private readonly ApplicationDbContext _context;

    public BidRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bid>> GetBidsByRoomIdAsync(int roomId)
    {
        return await _context.Bids.Where(b => b.RoomId == roomId).ToListAsync();
    }

    public async Task AddBidAsync(Bid bid)
    {
        _context.Bids.Add(bid);
        await _context.SaveChangesAsync();
    }
}
