﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinnessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        public List<AppUser> TUserListWithLocation();
        int TAppUserCount();
    }
}
