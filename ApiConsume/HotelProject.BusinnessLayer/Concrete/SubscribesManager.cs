

using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class SubscribesManager : ISubscribeService
    {
        private readonly ISubscribesDal _subscribesDal;

        public SubscribesManager(ISubscribesDal subscribesDal)
        {
            _subscribesDal = subscribesDal;
        }

        public void TDelete(Subscribe t)
        {
            _subscribesDal.Delete(t);
        }

        public Subscribe TGetById(int id)
        {
            return _subscribesDal.GetById(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subscribesDal.GetList();
        }

        public List<Subscribe> TGetListByFilter(Expression<Func<Subscribe, bool>> where)
        {
            return _subscribesDal.GetListByFilter(where);
        }

        public void TInsert(Subscribe t)
        {
            _subscribesDal.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            _subscribesDal.Update(t);
        }
    }
}
