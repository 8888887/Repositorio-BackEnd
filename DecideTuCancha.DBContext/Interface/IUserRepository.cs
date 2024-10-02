using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecideTuCancha.DBContext.Interface
{
    public interface IUserRepository
    {
        EntityBaseResponse Login(EntityLogin login);
    }
}
