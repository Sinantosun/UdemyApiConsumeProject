
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccsessLayer.Abstract
{
    public interface ISendMessageDal : IGenericDal<SendMessage>
    {
        public int GetMessageCount();
    }
}
