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
    public class EFSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EFSendMessageDal(Context context) : base(context)
        {
        }

        public int GetMessageCount()
        {
            var context = new Context();
            return context.sendMessages.Count();
        }
    }
}
