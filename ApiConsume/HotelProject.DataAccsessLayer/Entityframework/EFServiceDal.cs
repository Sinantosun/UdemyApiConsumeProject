
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFServiceDal : GenericRepository<Service>, IServicesDal
    {
        public EFServiceDal(Context context) : base(context)
        {
        }
    }
}
