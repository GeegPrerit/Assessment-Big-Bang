namespace Hotel_Management.Model;

public interface IRoomRepository
{
    Room GetRoomById(int id);
    IEnumerable<Room> GetAllRoom();
    void AddRoom(Room rooms);
    void UpdateRoom(Room rooms, int id);
    void DeleteRoom(int id);

}
