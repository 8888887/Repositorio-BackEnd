using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/complejo")]
    public class ComplejoController : Controller
    {
        protected readonly IComplejoRepository _complejoRepository;

        public ComplejoController(IComplejoRepository complejoRepository)
        {
            _complejoRepository = complejoRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetComplejos()
        {
            var rest = _complejoRepository.GetComplejos();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetComplejo(int id)
        {
            var rest = _complejoRepository.GetComplejo(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertComplejo([FromBody] EntityComplejo complejo)
        {
            var rest = _complejoRepository.InsertComplejo(complejo);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateComplejo([FromBody] EntityComplejo complejo)
        {
            var rest = _complejoRepository.UpdateComplejo(complejo);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteComplejo(int id)
        {
            var rest = _complejoRepository.DeleteComplejo(id);
            return Json(rest);
        }
    }
}
