using Microsoft.AspNetCore.Mvc;
using CineStar.Data;
using CineStar.Models;

namespace CineStar.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculaDAO _dao = new PeliculaDAO();

        // Esta acción responde a ~/Peliculas/Cartelera
        public IActionResult Cartelera()
        {
            // Usamos el ID 1 para Cartelera según tu base de datos
            var lista = _dao.ObtenerPeliculasPorEstado(1);
            return View(lista);
        }

        // Esta acción responde a ~/Peliculas/Estrenos
        public IActionResult Estrenos()
        {
            // Usamos el ID 2 para Estrenos
            var lista = _dao.ObtenerPeliculasPorEstado(2);
            return View(lista);
        }

        private PeliculaDAO _peliDAO = new PeliculaDAO();

        // Esta es la ruta que llama el botón: /Peliculas/Detalle/ID
        public IActionResult Detalle(int id)
        {
            var model = _peliDAO.ObtenerPelicula(id);
            if (model == null) return NotFound();
            return View(model);
        }
    }
}
