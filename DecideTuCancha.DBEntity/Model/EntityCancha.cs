using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntityCancha : EntityBase
    {
        public int IdCancha { get; set; }
        public int IdSede { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCancha { get; set; }

        public virtual EntitySede Sede { get; set; }
        public virtual EntityTipoCancha TipoCancha { get; set; }
    }

}
