using DecideTuCancha.DBEntity.Base;
using DecideTuCancha.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideTuCancha.DBContext.Interface
{
    public interface IUsuarioRepository
    {
        EntityBaseResponse GetUsuario(int id);
        EntityBaseResponse GetUsuarios();
        EntityBaseResponse InsertUsuario(EntityUsuario usuario);
        EntityBaseResponse UpdateUsuario(EntityUsuario usuario);
        EntityBaseResponse DeleteUsuario(int id);
        EntityBaseResponse Authenticate(string email, string contrasena);
    }
}
