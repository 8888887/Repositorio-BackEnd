using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/sede")]
    public class SedeController : Controller
    {
        protected readonly ISedeRepository _sedeRepository;

        public SedeController(ISedeRepository sedeRepository)
        {
            _sedeRepository = sedeRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetSedes()
        {
            var rest = _sedeRepository.GetSedes();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetSede(int id)
        {
            var rest = _sedeRepository.GetSede(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertSede([FromBody] EntitySede sede)
        {
            var rest = _sedeRepository.InsertSede(sede);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateSede([FromBody] EntitySede sede)
        {
            var rest = _sedeRepository.UpdateSede(sede);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteSede(int id)
        {
            var rest = _sedeRepository.DeleteSede(id);
            return Json(rest);
        }
    }
}
