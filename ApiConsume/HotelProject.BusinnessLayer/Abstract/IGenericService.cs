

using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        List<T> TGetList();

        T TGetById(int id);

        List<T> TGetListByFilter(Expression<Func<T, bool>> where);
    }
}
