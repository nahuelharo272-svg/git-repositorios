using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GimnasioAPI.Data;
using GimnasioAPI.Models;

namespace GimnasioAPI.Controllers
{
    // Esta ruta significa que para hablar con este controlador hay que ir a http://localhost:puerto/api/socios
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // El controlador "pide" el DbContext para poder hablar con la base de datos
        public SociosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/socios (Endpoint para registrar un socio nuevo)
        [HttpPost]
        public async Task<ActionResult<Socio>> PostSocio(Socio socio)
        {
            _context.Socios.Add(socio);
            await _context.SaveChangesAsync(); // Guarda en MySQL
            
            return Ok(socio); // Devuelve un 200 OK y los datos del socio guardado
        }

        // GET: api/socios/dni/12345678 (Endpoint para la pantalla de recepción)
        [HttpGet("dni/{dni}")]
        public async Task<ActionResult<Socio>> GetSocioPorDni(string dni)
        {
            // Busca en la tabla Socios el primero que coincida con el DNI
            var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Dni == dni);

            if (socio == null)
            {
                return NotFound(new { mensaje = "El DNI ingresado no existe en el sistema." }); // Devuelve un 404
            }

            return Ok(socio); // Devuelve los datos del socio (incluyendo su vencimiento)
        }
    }
}