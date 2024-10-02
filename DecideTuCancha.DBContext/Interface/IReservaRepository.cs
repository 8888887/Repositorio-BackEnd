using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface IReservaRepository
    {
        EntityBaseResponse GetReserva(int id);
        EntityBaseResponse GetReservas();
        EntityBaseResponse InsertReserva(EntityReserva reserva);
        EntityBaseResponse UpdateReserva(EntityReserva reserva);
        EntityBaseResponse DeleteReserva(int id);
        EntityBaseResponse GetReservasByCancha(int idCancha);
        EntityBaseResponse GetReservasByUsuario(int idUsuario);
    }
}
