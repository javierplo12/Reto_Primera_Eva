using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Reto_Primera_Eva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private static List<Pelicula> peliculas = new List<Pelicula>();

        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> GetPeliculas()
        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> GetPelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public ActionResult<Pelicula> CreatePelicula(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePelicula(int id, Pelicula updatedPelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            pelicula.Nombre = updatedPelicula.Nombre;
            pelicula.Director = updatedPelicula.Director;
            pelicula.Sinopsis = updatedPelicula.Sinopsis;
            pelicula.Duracion = updatedPelicula.Duracion;
            pelicula.FechaEstreno = updatedPelicula.FechaEstreno;
            pelicula.Genero = updatedPelicula.Genero;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            peliculas.Remove(pelicula);
            return NoContent();
        }

        // Método para inicializar datos
        public static void InicializarDatos()
        {
            peliculas.Add(new Pelicula(1, "Interstellar", "Javier Plo", "Un grupo de astronautas viaja a través de un agujero de gusano.", 169, new DateTime(2024, 11, 10), "Accion"));
            peliculas.Add(new Pelicula(2, "The Matrix", "Ruben Arnadillo", "Un hacker descubre que el mundo es una simulación.", 136, new DateTime(2024, 10, 19), "Miedo"));
        }
    }
}