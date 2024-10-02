using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface ISedeRepository
    {
        EntityBaseResponse GetSede(int id);
        EntityBaseResponse GetSedes();
        EntityBaseResponse InsertSede(EntitySede sede);
        EntityBaseResponse UpdateSede(EntitySede sede);
        EntityBaseResponse DeleteSede(int id);
    }
}
