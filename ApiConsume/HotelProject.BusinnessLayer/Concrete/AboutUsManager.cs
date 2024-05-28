using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAbouUsDal _abouUsDal;

        public AboutUsManager(IAbouUsDal abouUsDal)
        {
            _abouUsDal = abouUsDal;
        }

        public void TDelete(AboutUs t)
        {
            _abouUsDal.Delete(t);
        }

        public AboutUs TGetById(int id)
        {
            return _abouUsDal.GetById(id);
        }

        public List<AboutUs> TGetList()
        {
            return _abouUsDal.GetList();
        }

        public List<AboutUs> TGetListByFilter(Expression<Func<AboutUs, bool>> where)
        {
          return  _abouUsDal.GetListByFilter(where);
        }

        public void TInsert(AboutUs t)
        {
            _abouUsDal.Insert(t);
        }

        public void TUpdate(AboutUs t)
        {
            _abouUsDal.Update(t);
        }
    }
}
