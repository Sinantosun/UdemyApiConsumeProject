

using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class ServiceManager : IServicesService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void TDelete(Service t)
        {
            _servicesDal.Delete(t);
        }

        public Service TGetById(int id)
        {
            return _servicesDal.GetById(id);
        }

        public List<Service> TGetList()
        {
         return _servicesDal.GetList();
        }

        public List<Service> TGetListByFilter(Expression<Func<Service, bool>> where)
        {
            return _servicesDal.GetListByFilter(where);
        }

        public void TInsert(Service t)
        {
            _servicesDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _servicesDal.Update(t);
        }
    }
}
