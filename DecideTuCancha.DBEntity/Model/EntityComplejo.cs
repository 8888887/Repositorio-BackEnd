using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntityComplejo : EntityBase
    {
        public int IdComplejo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string UrlImagen { get; set; }
    }
}
