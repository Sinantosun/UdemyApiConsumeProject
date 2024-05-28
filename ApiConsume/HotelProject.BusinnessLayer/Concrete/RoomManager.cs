
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TDelete(Room t)
        {
            _roomDal.Delete(t);
        }

        public Room TGetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public List<Room> TgetLastThreeRooms()
        {
            return _roomDal.getLastThreeRooms();
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public List<Room> TGetListByFilter(Expression<Func<Room, bool>> where)
        {
            return _roomDal.GetListByFilter(where);
        }

        public void TInsert(Room t)
        {
            _roomDal.Insert(t);
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }
    }
}
