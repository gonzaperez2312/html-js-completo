using Microsoft.AspNetCore.Mvc;
using VeterinariaAPI.Models;
using VeterinariaAPI.Services;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly MascotaService _mascotaService;

        public MascotasController(MascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        public ActionResult<List<Mascota>> Get()
        {
            var mascotas = _mascotaService.ObtenerTodas();
            return Ok(mascotas);
        }

        [HttpGet("{codigo}")]
        public ActionResult<Mascota> Get(int codigo)
        {
            var mascota = _mascotaService.ObtenerPorCodigo(codigo);
            if (mascota == null)
                return NotFound();

            return Ok(mascota);
        }

        [HttpPost]
        public ActionResult<Mascota> Post([FromBody] Mascota mascota)
        {
            if (string.IsNullOrEmpty(mascota.Nombre) || 
                string.IsNullOrEmpty(mascota.Raza) || 
                string.IsNullOrEmpty(mascota.TipoMascota))
            {
                return BadRequest("Nombre, Raza y Tipo de Mascota son obligatorios");
            }

            var mascotaCreada = _mascotaService.Crear(mascota);
            return CreatedAtAction(nameof(Get), new { codigo = mascotaCreada.Codigo }, mascotaCreada);
        }

        [HttpPut("{codigo}")]
        public ActionResult Put(int codigo, [FromBody] Mascota mascota)
        {
            if (string.IsNullOrEmpty(mascota.Nombre) || 
                string.IsNullOrEmpty(mascota.Raza) || 
                string.IsNullOrEmpty(mascota.TipoMascota))
            {
                return BadRequest("Nombre, Raza y Tipo de Mascota son obligatorios");
            }

            var actualizado = _mascotaService.Actualizar(codigo, mascota);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(int codigo)
        {
            var eliminado = _mascotaService.Eliminar(codigo);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

