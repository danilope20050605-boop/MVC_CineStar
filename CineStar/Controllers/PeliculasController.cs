using Microsoft.AspNetCore.Mvc;
using CineStar.Data;
using CineStar.Models;

namespace CineStar.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculaDAO _dao = new PeliculaDAO();

        
        public IActionResult Cartelera()
        {
            
            var lista = _dao.ObtenerPeliculasPorEstado(1);
            return View(lista);
        }

        
        public IActionResult Estrenos()
        {
            
            var lista = _dao.ObtenerPeliculasPorEstado(2);
            return View(lista);
        }

        private PeliculaDAO _peliDAO = new PeliculaDAO();

        
        public IActionResult Detalle(int id)
        {
            var model = _peliDAO.ObtenerPelicula(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}
