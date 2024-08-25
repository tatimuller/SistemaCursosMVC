using Microsoft.AspNetCore.Mvc;
using SistemaCursos.Dados.Repositories;
using SistemaCursos.Model.DTOs;
using SistemaCursos.Model.Entities;

namespace SistemaCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository _alunoRepository;

        public AlunoController(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlunoDTO>> BuscarAlunos()
        {
            var alunos = _alunoRepository.BuscarTodos();
            // Mapeamento para DTO
            var alunosDTO = alunos.Select(a => new AlunoDTO
            {
                Id = a.Id,
                Nome = a.Nome,
                Endereco = a.Endereco,
                Email = a.EMail
            }).ToList();

            return Ok(alunosDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<AlunoDTO> BurscarAluno(int id)
        {
            var aluno = _alunoRepository.BuscarPeloId(id);
            if (aluno == null)
                return NotFound();

            var alunoDTO = new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Endereco = aluno.Endereco,
                Email = aluno.EMail
            };

            return Ok(alunoDTO);
        }

        [HttpPost]
        public IActionResult CadastrarAluno(AlunoDTO alunoDTO)
        {
            var aluno = new Aluno(alunoDTO.Nome, alunoDTO.Endereco, alunoDTO.Email);
            _alunoRepository.Adicionar(aluno);
            return CreatedAtAction(nameof(BurscarAluno), new { id = aluno.Id }, alunoDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AlterarAluno(int id, AlunoDTO alunoDTO)
        {
            var aluno = _alunoRepository.BuscarPeloId(id);
            if (aluno == null)
                return NotFound();

            aluno.AtualizarInformacoes(alunoDTO.Nome, alunoDTO.Endereco, alunoDTO.Email);
            _alunoRepository.Alterar(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ApagarAluno(int id)
        {
            var aluno = _alunoRepository.BuscarPeloId(id);
            if (aluno == null)
                return NotFound();

            _alunoRepository.Remover(id);
            return NoContent();
        }
    }
}
