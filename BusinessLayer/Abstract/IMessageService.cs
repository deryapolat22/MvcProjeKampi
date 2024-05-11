﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox();
        List<Message> GetListSendBox();
        void MessageAdd(Message Message);
        Message GetByID(int id);
        void MessageDelete(Message Message);
        void MessageUpdate(Message Message);
    }
}

