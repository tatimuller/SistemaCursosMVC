using Microsoft.AspNetCore.Mvc;
using SistemaCursos.Dados.Repositories;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorRepository _professorRepository;

        public ProfessorController(ProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var professores = _professorRepository.BuscarTodos();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _professorRepository.BuscarPorId(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _professorRepository.Adicionar(professor);
            return CreatedAtAction(nameof(GetById), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProfessor = _professorRepository.BuscarPorId(id);
            if (existingProfessor == null)
            {
                return NotFound();
            }

            existingProfessor.Nome = professor.Nome;
            existingProfessor.EMail = professor.EMail;

            _professorRepository.Alterar(existingProfessor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _professorRepository.BuscarPorId(id);
            if (professor == null)
            {
                return NotFound();
            }

            _professorRepository.Remover(id);
            return NoContent();
        }
    }
}
