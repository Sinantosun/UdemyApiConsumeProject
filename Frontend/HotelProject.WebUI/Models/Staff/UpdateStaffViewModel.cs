using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Models.Staff
{
    public class UpdateStaffViewModel
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocailMedia1 { get; set; }
        public string SocailMedia2 { get; set; }
        public string SocailMedia3 { get; set; }
    }
}
