

using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EFStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetFourStaffList()
        {
            var context = new Context();
            return context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
        }

        public int GetStaffCount()
        {
            var context = new Context();
            return context.Staffs.Count();
        }
    }
}
