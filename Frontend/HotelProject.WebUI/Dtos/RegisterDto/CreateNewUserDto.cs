using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad soyad boş bırakılamaz")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail boş bırakılamaz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar boş bırakılamaz")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
