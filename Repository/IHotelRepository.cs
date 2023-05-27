using Hotel_Management.Model;

namespace Hotel_Management.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotelById(int id);
        IEnumerable<Hotel> GetAllHotels();
        void AddHotel(Hotel hotel);
        void UpdateHotel(int id,Hotel hotel);
        void DeleteHotel(int id);
        
    }
}
