

using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnessLayer.Abstract
{
    public interface IRoomService : IGenericService<Room>
    {
        List<Room> TgetLastThreeRooms();
    }
}
