using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entrelinhas.Data;
using Entrelinhas.Models;

namespace Entrelinhas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Buscar por nome de cada cliente/usuário
        [HttpGet("/filtrar/{nome}")]
        public async Task<IActionResult> BuscarNome(string nome)
        {
            var listaClientes = _context.Usuario.Where(c => c.Nome.Contains(nome)).ToList();
            if (listaClientes.Count > 0)
            {
                return Ok(listaClientes);
            }
            return NotFound(nome);
        }

        //Paginação de registro de usuários
        [HttpGet("/paginacao/{numeroPagina}/{qtdadeRegistros}")]
        public async Task<IActionResult> Paginacao(int numeroPagina, int qtdadeRegistros)
        {
            var totalItens = await _context.Usuario.CountAsync();
            var pularRegistros = (numeroPagina - 1) * qtdadeRegistros;
            var listaClientes = await _context.Usuario.Skip(pularRegistros).Take(qtdadeRegistros).ToListAsync();
            if (listaClientes.Count >= 0)
            {
                return Ok(listaClientes);
            }
            return NoContent();
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
