using Hotel_Management.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Repository
{
    public class CountFilterRepository : ICountFilterRepository
    {
        private readonly HotelRoomDBContext _dbContext;

        public CountFilterRepository(HotelRoomDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Hotel> GetFilteredHotels(string location, decimal? minPrice, decimal? maxPrice)
        {
            var hotels = _dbContext.Set<Hotel>().AsQueryable();
            var rooms = _dbContext.Set<Room>().AsQueryable();

            if (!string.IsNullOrEmpty(location))
                hotels = hotels.Where(h => h.Location.Contains(location));

            if (minPrice != null)
                rooms = rooms.Where(h => h.Price >= minPrice);

            if (maxPrice != null)
                rooms = rooms.Where(h => h.Price <= maxPrice);

            return hotels.ToList();
        }

        public int Results(int id)
        {
            Hotel hotel = _dbContext.Hotels.FirstOrDefault(h => h.Id == id);

            // Count the available rooms in the hotel
            int availableRoomsCount = _dbContext.Rooms.Count(r => r.HotelId ==id && r.Availability == true);

            return availableRoomsCount;

        }

        public async Task<TokenGenerationCount> GetTokenGenerationCountByUserName(string userName)
        {
            return await _dbContext.TokenGenerationCounts.FirstOrDefaultAsync(t => t.UserName == userName);
        }

        public async Task UpdateTokenGenerationCount(TokenGenerationCount tokenCount)
        {
            if (tokenCount.Id == 0)
            {
                _dbContext.TokenGenerationCounts.Add(tokenCount);
            }
            else
            {
                _dbContext.TokenGenerationCounts.Update(tokenCount);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
