﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class SendMessage
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
