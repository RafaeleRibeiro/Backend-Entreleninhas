﻿using System;
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
    public class LivrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            return await _context.Livro.ToListAsync();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(Guid id)
        {
            var livro = await _context.Livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(Guid id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = livro.LivroId }, livro);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(Guid id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/buscarTitulo/{titulo}")]
        public async Task<IActionResult> BuscaPorTitulo(string titulo)
        {
            var listaLivros = await _context.Livro.Where(l => l.Titulo.Contains(titulo)).ToListAsync();
            if (listaLivros.Count > 0)
            {
                return Ok(listaLivros);
            }
            return NotFound();
        }

        [HttpGet("/buscarAutor/{autor}")]
        public async Task<IActionResult> BuscaPorAutor(string autor)
        {
            var listaLivros = await _context.Livro.Where(l => l.Titulo.Contains(autor)).ToListAsync();
            if (listaLivros.Count > 0)
            {
                return Ok(listaLivros);
            }
            return NotFound();
        }

        [HttpGet("/buscarEditora/{editora}")]
        public async Task<IActionResult> BuscaPorEditora(string editora)
        {
            var listaLivros = await _context.Livro.Where(l => l.Titulo.Contains(editora)).ToListAsync();
            if (listaLivros.Count > 0)
            {
                return Ok(listaLivros);
            }
            return NotFound();
        }
        private bool LivroExists(Guid id)
        {
            return _context.Livro.Any(e => e.LivroId == id);
        }
    }
}
