using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class MisionesController : Controller
    {

        /// <summary>
        /// Llama al index con la lista de misiones
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// hace un post para acceder a los datos de los candidatos disponibles para la mision seleccionada al pulsar el boton
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Busca los datos completos del Candidato para mostrar sus detalles en una nueva vista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
