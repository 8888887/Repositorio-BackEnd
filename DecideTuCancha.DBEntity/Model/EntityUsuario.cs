using DecideTuCancha.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBEntity.Model
{
    public class EntityUsuario : EntityBase
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
