namespace HotelProject.WebUI.Dtos.ConatctDto
{
    public class CreateContactDto
    {

        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime Date { get; set; }
    }
}
