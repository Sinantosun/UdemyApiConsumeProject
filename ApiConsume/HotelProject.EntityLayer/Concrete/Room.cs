﻿
namespace HotelProject.EntityLayer.Concrete
{
    public class Room
    {

        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        public decimal Price { get; set; }
        public decimal Title { get; set; }
        public int Star { get; set; }
        public string BedCount { get; set; }
        public string BathCount { get; set; }
        public string Description { get; set; }
        public bool Wifi { get; set; }
    }
}
