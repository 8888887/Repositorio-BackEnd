using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntitySede : EntityBase
    {
        public int IdSede { get; set; }
        public int IdComplejo { get; set; }
        public string Nombre { get; set; }

        public virtual EntityComplejo Complejo { get; set; }
    }
}
