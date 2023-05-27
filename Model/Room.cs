using System.ComponentModel.DataAnnotations;
namespace Hotel_Management.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }

        public decimal Price { get; set; }

        public string? RoomType { get; set; }

        public bool Availability { get; set; }

        // Other properties specific to a room

        public Hotel? Hotel { get; set; }
    }
}
