using AplicacionCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionCRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private sistemaUsuariosContext _context;

        public TransaccionesController(sistemaUsuariosContext context)
        {
            _context = context;
        }

        //GET --> Enlistar todas las transacciones en la raiz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccione>>> GetTransacciones()
        {
            return await _context.Transacciones.ToListAsync();
        }

        //POST --> Insertar registros en la DB
        [HttpPost]
        public async Task<ActionResult<Transaccione>> PostTransaccion(Transaccione transaccion)
        {
            _context.Transacciones.Add(transaccion);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(TransaccioneExists(transaccion.CodigoUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetTransacciones", new { id = transaccion.CodigoUsuario }, transaccion);
        }

        private bool TransaccioneExists(string id)
        {
            return _context.Transacciones.Any(e => e.CodigoUsuario == id);
        }
    }
}
