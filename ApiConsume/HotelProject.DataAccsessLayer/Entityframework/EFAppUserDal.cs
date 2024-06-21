using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccsessLayer.Entityframework
{
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EFAppUserDal(Context context) : base(context)
        {
        }

        public int AppUserCount()
        {
            var context = new Context();
            return context.Users.Count();
        }

        public List<AppUser> UserListWithLocation()
        {
            var context = new Context();
            return context.Users.Include(t => t.WorkLocation).ToList();
        }
    }
}
