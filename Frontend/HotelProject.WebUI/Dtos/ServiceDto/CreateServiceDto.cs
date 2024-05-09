using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="İkon yaznız")]
        public string Icon { get; set; }
        [Required(ErrorMessage = "Başlık yaznız")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama yaznız")]
        [MaxLength(500, ErrorMessage = "Başlık en fazla 500 karakter olmalıdır.")]
        public string Description { get; set; }
    }
}
