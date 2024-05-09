
using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
    public class CreateRoomDto
    {
        [Required(ErrorMessage ="Lütfen oda numarasını yazınız")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat bilgisi yazınız")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Lütfen başlık bilgisi yazınız")]
        public string Title { get; set; }
        public double Star { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisini yazınız")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı bilgisini yazınız")]
        public string BathCount { get; set; }
        public string Description { get; set; }
        public bool Wifi { get; set; }
    }
}
