

using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnessLayer.Abstract
{
    public interface IStaffService : IGenericService<Staff>
    {
        int TGetStaffCount();
        List<Staff> TGetFourStaffList();

    }
}
