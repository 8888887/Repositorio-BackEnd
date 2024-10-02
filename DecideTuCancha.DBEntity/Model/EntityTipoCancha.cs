using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntityTipoCancha : EntityBase
    {
        public int IdTipoCancha { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
