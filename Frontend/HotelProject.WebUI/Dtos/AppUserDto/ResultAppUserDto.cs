using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {
        public string NameSurname { get; set; }
        public string City { get; set; }
        public string ImageURL { get; set; }
        public string WorkDepartmant { get; set; }

        public string Country { get; set; }
        public string Gender { get; set; }

        public int WorkLocationID { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}
