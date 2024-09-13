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
    public class DoacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Doacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doacao>>> GetDoacao()
        {
            return await _context.Doacao.ToListAsync();
        }

        // GET: api/Doacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doacao>> GetDoacao(Guid id)
        {
            var doacao = await _context.Doacao.FindAsync(id);

            if (doacao == null)
            {
                return NotFound();
            }

            return doacao;
        }

        // PUT: api/Doacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoacao(Guid id, Doacao doacao)
        {
            if (id != doacao.DoacaoId)
            {
                return BadRequest();
            }

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoacaoExists(id))
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

        // POST: api/Doacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doacao>> PostDoacao(Doacao doacao)
        {
            _context.Doacao.Add(doacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoacao", new { id = doacao.DoacaoId }, doacao);
        }

        // DELETE: api/Doacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoacao(Guid id)
        {
            var doacao = await _context.Doacao.FindAsync(id);
            if (doacao == null)
            {
                return NotFound();
            }

            _context.Doacao.Remove(doacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/filtrarPorDoacao/{doacoes}")]
        public async Task<IActionResult> NomeDoacao(string doacoes)
        {
            var listaDoacoes = await _context.Doacao.Where(d => d.Usuario.ToString().Contains(doacoes)).ToListAsync();
            if (listaDoacoes.Count() > 0)
            {
                return Ok(listaDoacoes);
            }
            return NotFound();
        }

        private bool DoacaoExists(Guid id)
        {
            return _context.Doacao.Any(e => e.DoacaoId == id);
        }
    }
}
