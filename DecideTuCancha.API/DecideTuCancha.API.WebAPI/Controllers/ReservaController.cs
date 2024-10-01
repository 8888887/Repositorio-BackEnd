using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBEntity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DecideTuCancha.API
{
    [Produces("application/json")]
    [Route("api/reserva")]
    public class ReservaController : Controller
    {
        protected readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetReservas()
        {
            var rest = _reservaRepository.GetReservas();
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetReserva(int id)
        {
            var rest = _reservaRepository.GetReserva(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPost]
        [Route("insertar")]
        public ActionResult InsertReserva([FromBody] EntityReserva reserva)
        {
            var rest = _reservaRepository.InsertReserva(reserva);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpPut]
        [Route("actualizar")]
        public ActionResult UpdateReserva([FromBody] EntityReserva reserva)
        {
            var rest = _reservaRepository.UpdateReserva(reserva);
            return Json(rest);
        }

        [Produces("application/json")]
        [HttpDelete]
        [Route("eliminar")]
        public ActionResult DeleteReserva(int id)
        {
            var rest = _reservaRepository.DeleteReserva(id);
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar-por-cancha")]
        public ActionResult GetReservasByCancha(int idCancha)
        {
            var rest = _reservaRepository.GetReservasByCancha(idCancha);
            return Json(rest);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar-por-usuario")]
        public ActionResult GetReservasByUsuario(int idUsuario)
        {
            var rest = _reservaRepository.GetReservasByUsuario(idUsuario);
            return Json(rest);
        }
    }
}
