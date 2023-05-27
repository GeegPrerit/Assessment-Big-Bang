using Hotel_Management.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Repository
{
    public interface ICountFilterRepository
    {
        
            // Existing methods...
            IEnumerable<Hotel> GetFilteredHotels(string location, decimal? minPrice, decimal? maxPrice);

            int Results(int id);

            Task<TokenGenerationCount> GetTokenGenerationCountByUserName(string userName);
            Task UpdateTokenGenerationCount(TokenGenerationCount tokenCount);
    }
}
