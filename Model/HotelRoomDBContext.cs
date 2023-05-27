using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Model
{
    public class HotelRoomDBContext:DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<TokenGenerationCount> TokenGenerationCounts { get; set; }


        public HotelRoomDBContext(DbContextOptions<HotelRoomDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as per your requirements

            // Additional configuration for entities and relationships can be defined here
        }
    }
}
