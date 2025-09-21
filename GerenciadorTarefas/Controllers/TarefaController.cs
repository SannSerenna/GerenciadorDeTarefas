using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTodos()
        {
            return await _context.Tarefas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> ObterPorId(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            return tarefa;
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterPorTitulo(string titulo)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Titulo.Contains(titulo))
                .ToListAsync();
            return tarefas;
        }

        [HttpGet("ObterPorData")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterPorData(DateTime data)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Data.Date == data.Date)
                .ToListAsync();
            return tarefas;
        }

        [HttpGet("ObterPorStatus")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterPorStatus(string status)
        {
            var tarefas = await _context.Tarefas
                .Where(t => t.Status == status)
                .ToListAsync();
            return tarefas;
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Criar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id) return BadRequest();

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tarefas.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}