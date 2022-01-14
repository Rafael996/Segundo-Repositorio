using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Connection;
using api.Models.Tipos;
using api.Models;
using AutoMapper;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly ConnectionContext _context;
        private readonly IMapper _mapper;

        public PessoasController(ConnectionContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Getpessoas()
        {
           var pessoa = await _context.pessoas.ToListAsync();

           var PessoaRetorno = _mapper.Map<PessoasDTO>(pessoa);

            return PessoaRetorno != null ? Ok(PessoaRetorno) : BadRequest();   

        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetById(int id)
        {
            var pessoa = await _context.pessoas.FindAsync(id);

          
            var PessoaRetorno = _mapper.Map<PessoasDTO>(pessoa);

           

            return PessoaRetorno != null ? Ok(PessoaRetorno) : BadRequest("Pessoa não encontrada");    
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id) return BadRequest();

           

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Atualizado");
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            _context.pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var pessoa = await _context.pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoaExists(int id)
        {
            return _context.pessoas.Any(e => e.Id == id);
        }
    }
}
