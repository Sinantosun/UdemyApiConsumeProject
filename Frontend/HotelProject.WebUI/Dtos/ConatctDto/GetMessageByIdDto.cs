namespace HotelProject.WebUI.Dtos.ConatctDto
{
    public class GetMessageByIdDto
    {
        public int SendMessageID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string SenderName { get; set; }
        public string SenderMail { get; set; }

        public string ReciverMail { get; set; }
        public string ReciverName { get; set; }

        public DateTime SenderDate { get; set; }
    }
}
