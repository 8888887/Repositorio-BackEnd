using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface ICanchaRepository
    {
        EntityBaseResponse GetCancha(int id);
        EntityBaseResponse GetCanchas();
        EntityBaseResponse InsertCancha(EntityCancha cancha);
        EntityBaseResponse UpdateCancha(EntityCancha cancha);
        EntityBaseResponse DeleteCancha(int id);
    }
}
