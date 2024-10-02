using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/tipocancha")]
    public class TipoCanchaController : Controller
    {
        protected readonly ITipoCanchaRepository _tipoCanchaRepository;

        public TipoCanchaController(ITipoCanchaRepository tipoCanchaRepository)
        {
            _tipoCanchaRepository = tipoCanchaRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetTiposCancha()
        {
            var rest = _tipoCanchaRepository.GetTiposCancha();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetTipoCancha(int id)
        {
            var rest = _tipoCanchaRepository.GetTipoCancha(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertTipoCancha([FromBody] EntityTipoCancha tipoCancha)
        {
            var rest = _tipoCanchaRepository.InsertTipoCancha(tipoCancha);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateTipoCancha([FromBody] EntityTipoCancha tipoCancha)
        {
            var rest = _tipoCanchaRepository.UpdateTipoCancha(tipoCancha);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteTipoCancha(int id)
        {
            var rest = _tipoCanchaRepository.DeleteTipoCancha(id);
            return Json(rest);
        }
    }
}
