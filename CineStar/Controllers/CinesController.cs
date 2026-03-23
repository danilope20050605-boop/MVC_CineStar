using CineStar.Data;
using Microsoft.AspNetCore.Mvc;

namespace CineStar.Controllers
{
    public class CinesController : Controller
    {
        private CineDAO _cineDAO = new CineDAO();

        // Ruta: /Cines (Lista completa - image_14.png)
        public IActionResult Index()
        {
            var model = _cineDAO.ObtenerCines();
            return View(model);
        }

        // Ruta: /Cines/Detalle/ID (image_15.png)
        public IActionResult Detalle(int id)
        {
            var model = _cineDAO.ObtenerCineDetalle(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}
