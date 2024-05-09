using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Bu alan gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu alan gereklidir.")]
        public string Password { get; set; }
    }
}
