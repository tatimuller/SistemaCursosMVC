using Microsoft.AspNetCore.Mvc;
using SistemaCursos.Dados.Repositories;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursoRepository _cursoRepository;

        public CursoController(CursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cursos = _cursoRepository.BuscarTodos();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var curso = _cursoRepository.BuscarPeloId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _cursoRepository.Adicionar(curso);
            return CreatedAtAction(nameof(GetById), new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCurso = _cursoRepository.BuscarPeloId(id);
            if (existingCurso == null)
            {
                return NotFound();
            }

            existingCurso.Titulo = curso.Titulo;
            existingCurso.Descricao = curso.Descricao;

            _cursoRepository.Alterar(existingCurso);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var curso = _cursoRepository.BuscarPeloId(id);
            if (curso == null)
            {
                return NotFound();
            }

            _cursoRepository.Remover(id);
            return NoContent();
        }
    }
}
