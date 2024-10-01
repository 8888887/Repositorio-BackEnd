using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/cancha")]
    public class CanchaController : Controller
    {
        protected readonly ICanchaRepository _canchaRepository;

        public CanchaController(ICanchaRepository canchaRepository)
        {
            _canchaRepository = canchaRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetCanchas()
        {
            var rest = _canchaRepository.GetCanchas();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetCancha(int id)
        {
            var rest = _canchaRepository.GetCancha(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertCancha([FromBody] EntityCancha cancha)
        {
            var rest = _canchaRepository.InsertCancha(cancha);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateCancha([FromBody] EntityCancha cancha)
        {
            var rest = _canchaRepository.UpdateCancha(cancha);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteCancha(int id)
        {
            var rest = _canchaRepository.DeleteCancha(id);
            return Json(rest);
        }
    }
}
