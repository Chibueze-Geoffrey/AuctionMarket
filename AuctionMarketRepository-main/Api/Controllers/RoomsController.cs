using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBidRepository _bidRepository;

    public RoomsController(IRoomRepository roomRepository, IBidRepository bidRepository)
    {
        _roomRepository = roomRepository;
        _bidRepository = bidRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] Room room)
    {
        await _roomRepository.CreateRoomAsync(room);
        return Ok(room);
    }

    [HttpPost("{id}/bids")]
    public async Task<IActionResult> SubmitBid(int id, [FromBody] Bid bid)
    {
        var room = await _roomRepository.GetRoomAsync(id);
        if (room == null)
            return NotFound();

        await _bidRepository.AddBidAsync(bid);
        return Ok();
    }

    [HttpGet("{id}/bids")]
    public async Task<IActionResult> GetBids(int id)
    {
        var bids = await _bidRepository.GetBidsByRoomIdAsync(id);
        return Ok(bids);
    }
}
