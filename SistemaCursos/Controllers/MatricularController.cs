using Microsoft.AspNetCore.Mvc;
using SistemaCursos.Dados.Repositories;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaRepository _matriculaRepository;

        public MatriculaController(MatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var matriculas = _matriculaRepository.BuscarTodos;
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var matricula = _matriculaRepository.BuscarPorId(id);
            if (matricula == null)
            {
                return NotFound();
            }
            return Ok(matricula);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _matriculaRepository.Adicionar(matricula);
            return CreatedAtAction(nameof(GetById), new { id = matricula.Id }, matricula);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingMatricula = _matriculaRepository.BuscarPorId(id);
            if (existingMatricula == null)
            {
                return NotFound();
            }

            existingMatricula.DataMatricula = matricula.DataMatricula;
            existingMatricula.Status = matricula.Status;

            _matriculaRepository.Alterar(existingMatricula);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matricula = _matriculaRepository.BuscarPorId(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _matriculaRepository.Remover(id);
            return NoContent();
        }
    }
}
