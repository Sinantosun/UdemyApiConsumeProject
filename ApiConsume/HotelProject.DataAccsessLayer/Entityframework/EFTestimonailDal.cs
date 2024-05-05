
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFTestimonailDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EFTestimonailDal(Context context) : base(context)
        {
        }
    }
}
