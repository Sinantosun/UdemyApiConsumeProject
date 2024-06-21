

using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFRoomDal : GenericRepository<Room>, IRoomDal
    {
        private readonly Context _context;
        public EFRoomDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Room> getLastThreeRooms()
        {
            return _context.Rooms.OrderByDescending(x => x.RoomId).Take(3).ToList();
        }

        public int GetRoomCount()
        {
            return _context.Rooms.Count();
        }
    }
}
