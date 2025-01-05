using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class MisionesController : Controller
    {
        public IActionResult Index()
        {
            var misiones = clsGestorMisionesBL.ObtenerMisiones();
            var viewModel = new MisionesCandidatosViewModel
            {
                Misiones = misiones,
                Candidatos = new List<clsCandidato>(),
                MisionSeleccionadaId = 0
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(MisionesCandidatosViewModel viewModel)
        {
            var misiones = clsGestorMisionesBL.ObtenerMisiones();
            viewModel.Misiones = misiones;

            if (viewModel.MisionSeleccionadaId > 0)
            {
                viewModel.Candidatos = clsGestorCandidatosBL.ObtenerCandidatosPorMision(viewModel.MisionSeleccionadaId);
            }
            else
            {
                viewModel.Candidatos = new List<clsCandidato>();
            }

            return View(viewModel);
        }

        public IActionResult DetallesCandidato(int id)
        {
            var candidato = clsGestorCandidatosBL.ObtenerCandidatoPorId(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

    }
}
