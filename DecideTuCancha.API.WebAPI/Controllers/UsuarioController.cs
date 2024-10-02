using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        protected readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetUsuarios()
        {
            var rest = _usuarioRepository.GetUsuarios();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetUsuario(int id)
        {
            var rest = _usuarioRepository.GetUsuario(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertUsuario([FromBody] EntityUsuario usuario)
        {
            var rest = _usuarioRepository.InsertUsuario(usuario);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateUsuario([FromBody] EntityUsuario usuario)
        {
            var rest = _usuarioRepository.UpdateUsuario(usuario);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteUsuario(int id)
        {
            var rest = _usuarioRepository.DeleteUsuario(id);
            return Json(rest);
        }
    }
}
