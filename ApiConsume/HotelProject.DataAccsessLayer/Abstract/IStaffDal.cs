using HotelProject.EntityLayer.Concrete;


namespace HotelProject.DataAccsessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        int GetStaffCount();

        List<Staff> GetFourStaffList();
    }
}
