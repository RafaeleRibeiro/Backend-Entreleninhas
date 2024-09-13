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
    public class ItensCarrinhosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItensCarrinhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItensCarrinhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensCarrinho>>> GetItensCarrinho()
        {
            return await _context.ItensCarrinho.ToListAsync();
        }

        // GET: api/ItensCarrinhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensCarrinho>> GetItensCarrinho(Guid id)
        {
            var itensCarrinho = await _context.ItensCarrinho.FindAsync(id);

            if (itensCarrinho == null)
            {
                return NotFound();
            }

            return itensCarrinho;
        }

        // PUT: api/ItensCarrinhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensCarrinho(Guid id, ItensCarrinho itensCarrinho)
        {
            if (id != itensCarrinho.ItensCarrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(itensCarrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensCarrinhoExists(id))
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

        // POST: api/ItensCarrinhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensCarrinho>> PostItensCarrinho(ItensCarrinho itensCarrinho)
        {
            _context.ItensCarrinho.Add(itensCarrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItensCarrinho", new { id = itensCarrinho.ItensCarrinhoId }, itensCarrinho);
        }

        // DELETE: api/ItensCarrinhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensCarrinho(Guid id)
        {
            var itensCarrinho = await _context.ItensCarrinho.FindAsync(id);
            if (itensCarrinho == null)
            {
                return NotFound();
            }

            _context.ItensCarrinho.Remove(itensCarrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensCarrinhoExists(Guid id)
        {
            return _context.ItensCarrinho.Any(e => e.ItensCarrinhoId == id);
        }
    }
}
