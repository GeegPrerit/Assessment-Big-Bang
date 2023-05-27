using Hotel_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelRoomDBContext _dbContext;

        public HotelRepository(HotelRoomDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddHotel(Hotel hotel)
        {
            _dbContext.Set<Hotel>().Add(hotel);
            _dbContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = _dbContext.Hotels.Find(id);
            _dbContext.Remove(hotel);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _dbContext.Set<Hotel>().Include(a =>a.Rooms).ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return _dbContext.Set<Hotel>().Find(id);
        }

        public void UpdateHotel(int id,Hotel hotel)
        {
            var res1 = _dbContext.Hotels.Find(id);
            res1.Name=hotel.Name;
            res1.Location = hotel.Location;
            res1.Rating = hotel.Rating;
             
            
            _dbContext.Hotels.Update(res1);
            _dbContext.SaveChanges();


        }
    }
}
