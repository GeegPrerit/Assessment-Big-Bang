using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Model
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Location { get; set; }

        public string? Rating { get; set; }

        public List<Room>? Rooms { get; set; }


    }
}
