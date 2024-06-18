﻿using HotelProject.DataAccsessLayer.Abstract;
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
    public class EFGuestDal : GenericRepository<Guest>, IGuestDal
    {
        public EFGuestDal(Context context) : base(context)
        {
        }
    }
}
