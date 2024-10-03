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
    public class ParticipacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Participacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participacao>>> GetParticipacoes()
        {
            return await _context.Participacoes.ToListAsync();
        }

        // GET: api/Participacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participacao>> GetParticipacao(Guid id)
        {
            var participacao = await _context.Participacoes.FindAsync(id);

            if (participacao == null)
            {
                return NotFound();
            }

            return participacao;
        }

        // PUT: api/Participacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipacao(Guid id, Participacao participacao)
        {
            if (id != participacao.ParticipacaoId)
            {
                return BadRequest();
            }

            _context.Entry(participacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipacaoExists(id))
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

        // POST: api/Participacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participacao>> PostParticipacao(Participacao participacao)
        {
            _context.Participacoes.Add(participacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipacao", new { id = participacao.ParticipacaoId }, participacao);
        }

        // DELETE: api/Participacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipacao(Guid id)
        {
            var participacao = await _context.Participacoes.FindAsync(id);
            if (participacao == null)
            {
                return NotFound();
            }

            _context.Participacoes.Remove(participacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipacaoExists(Guid id)
        {
            return _context.Participacoes.Any(e => e.ParticipacaoId == id);
        }
    }
}
