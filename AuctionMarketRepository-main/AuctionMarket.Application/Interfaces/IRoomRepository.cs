public interface IRoomRepository
{
    Task<Room> GetRoomAsync(int id);
    Task CreateRoomAsync(Room room);
    Task UpdateRoomAsync(Room room);
}
