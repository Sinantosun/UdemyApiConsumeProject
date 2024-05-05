
using HotelProject.BusinnessLayer.Abstract;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace HotelProject.BusinnessLayer.Concrete
{
    public class TestimonialManager : ITestimonailService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public List<Testimonial> TGetListByFilter(Expression<Func<Testimonial, bool>> where)
        {
            return _testimonialDal.GetListByFilter(where);
        }

        public void TInsert(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }
       
        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
