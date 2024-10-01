using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface ITipoCanchaRepository
    {
        EntityBaseResponse GetTipoCancha(int id);
        EntityBaseResponse GetTiposCancha();
        EntityBaseResponse InsertTipoCancha(EntityTipoCancha tipoCancha);
        EntityBaseResponse UpdateTipoCancha(EntityTipoCancha tipoCancha);
        EntityBaseResponse DeleteTipoCancha(int id);
    }
}
