

using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffdal;

        public StaffManager(IStaffDal staffdal)
        {
            _staffdal = staffdal;
        }

        public void TDelete(Staff t)
        {
            _staffdal.Delete(t);
        }

        public Staff TGetById(int id)
        {
            return _staffdal.GetById(id);
        }

        public List<Staff> TGetFourStaffList()
        {
            return _staffdal.GetFourStaffList();
        }

        public List<Staff> TGetList()
        {
         return   _staffdal.GetList();
        }

        public List<Staff> TGetListByFilter(Expression<Func<Staff, bool>> where)
        {
            return _staffdal.GetListByFilter(where);
        }

        public int TGetStaffCount()
        {
            return _staffdal.GetStaffCount();
        }

        public void TInsert(Staff t)
        {
            _staffdal.Insert(t);
        }

        public void TUpdate(Staff t)
        {
            _staffdal.Update(t);
        }
    }
}
