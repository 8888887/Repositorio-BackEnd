using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntityReserva : EntityBase
    {
        public int IdReserva { get; set; }
        public int IdCancha { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public virtual EntityCancha Cancha { get; set; }
        public virtual EntityUsuario Usuario { get; set; }
    }
}
