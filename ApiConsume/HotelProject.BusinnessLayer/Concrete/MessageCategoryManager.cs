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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategoryDal = messageCategoryDal;
        }

        public void TDelete(MessageCategory t)
        {
            _messageCategoryDal.Delete(t);
        }

        public MessageCategory TGetById(int id)
        {
            return _messageCategoryDal.GetById(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategoryDal.GetList();
        }

        public List<MessageCategory> TGetListByFilter(Expression<Func<MessageCategory, bool>> where)
        {
            return _messageCategoryDal.GetListByFilter(where);
        }

        public void TInsert(MessageCategory t)
        {
            _messageCategoryDal.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _messageCategoryDal.Update(t);
        }
    }
}
