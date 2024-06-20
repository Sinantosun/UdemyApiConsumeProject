using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class WorkLocation
    {
        public int WorkLocationID { get; set; }
        public string LocationName { get; set; }
        public string CityName { get; set; }


        public List<AppUser> Users { get; set; }
    }
}
