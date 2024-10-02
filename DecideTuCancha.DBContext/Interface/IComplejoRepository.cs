using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface IComplejoRepository
    {
        EntityBaseResponse GetComplejo(int id);
        EntityBaseResponse GetComplejos();
        EntityBaseResponse InsertComplejo(EntityComplejo complejo);
        EntityBaseResponse UpdateComplejo(EntityComplejo complejo);
        EntityBaseResponse DeleteComplejo(int id);
    }
}
