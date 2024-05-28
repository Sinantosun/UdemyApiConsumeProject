using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Abstract
{
    public interface IRoomDal : IGenericDal<Room>
    {
        List<Room> getLastThreeRooms();
    }
}
