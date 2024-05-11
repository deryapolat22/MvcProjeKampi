using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }



        public List<Message> GetListInBox()
        {
            return _messagedal.List(x => x.ReceiverMail == "dpolat@tasdelengroup.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messagedal.List(x => x.SenderMail == "dpolat@tasdelengroup.com");
        }

        public void MessageAdd(Message Message)
        {
            _messagedal.Insert(Message);
        }

        public void MessageDelete(Message Message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message Message)
        {
            throw new NotImplementedException();
        }
    }
}
