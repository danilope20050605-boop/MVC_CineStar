namespace CineStar.Models
{
    public class Cine
    {
        // Datos básicos
        public int Id { get; set; } // Usar Mayúscula ayuda a que coincida con tus vistas

        // Mantenemos Nombre para que tus archivos .cshtml no fallen
        public string Nombre { get; set; }

        public string RazonSocial { get; set; }
        public int Salas { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public string Distrito { get; set; }

        // Datos para el detalle
        public List<Tarifa> ListaTarifas { get; set; }
        public List<PeliculaHorario> ListaPeliculas { get; set; }
    }

    public class Tarifa
    {
        public string Dias { get; set; }
        public string Precio { get; set; }
    }

    public class PeliculaHorario
    {
        public string Titulo { get; set; }
        public string Horarios { get; set; }
    }
}
