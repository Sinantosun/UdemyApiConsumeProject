using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EFBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusChangeApproved(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Status = "Onaylandı";
            _context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Status = "İptal Edildi";
            _context.SaveChanges();
        }
        public void BookingStatusChangeWait(int id)
        {
            var value = _context.Bookings.Find(id);
            value.Status = "Beklemede,Müşteri Aranacak";
            _context.SaveChanges();
        }
        public int GetBookingCount()
        {
            return _context.Bookings.Count();
        }

        public List<Booking> GetLastSixBookingList()
        {
            return _context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
        }
    }
}
