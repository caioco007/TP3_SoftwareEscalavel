using Microsoft.AspNetCore.Mvc;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.Services.Integration;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;
using TP3_SoftwareEscalavel.Core.Entities;

namespace Professor.API.Controllers
{
    [Route("/professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IChamadaService _chamadaService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividadeAlunosService _atividadeAlunosService;
        private readonly IAlunoIntegration _alunoIntegration;
        public ProfessorController(IProfessorService professorService, IChamadaService chamadaService, IAtividadeService atividadeService, IAlunoIntegration alunoIntegration, IAtividadeAlunosService atividadeAlunosService)
        {
            _professorService = professorService;
            _chamadaService = chamadaService;
            _atividadeService = atividadeService;
            _alunoIntegration = alunoIntegration;
            _atividadeAlunosService = atividadeAlunosService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alunos = _professorService.GetAll();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _professorService.GetById(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _professorService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProfessorInputModel inputModel)
        {
            if (inputModel.Nome.Length > 50)
            {
                return BadRequest();
            }

            var id = _professorService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateProfessorInputModel inputModel)
        {
            if (inputModel.Nome.Length > 50)
            {
                return BadRequest();
            }

            _professorService.Update(inputModel);

            return NoContent();
        }

        [HttpGet("/chamada")]
        public IActionResult GetAllChamada()
        {
            var chamadas = _chamadaService.GetAll();
            return Ok(chamadas);
        }

        [HttpGet("/chamada/{dataCriacao}")]
        public IActionResult GetChamadaByDataCriacao(string dataCriacao)
        {

            DateTime? dataFormatada = null;
            if (DateTime.TryParse(dataCriacao, out var data)) dataFormatada = data;

            if (!dataFormatada.HasValue) return NotFound("Data em formato inválido");

            var chamada = _chamadaService.GetByDataCriacao(dataFormatada.Value);

            if (chamada == null)
            {
                return NotFound();
            }

            return Ok(chamada);
        }

        [HttpPost("/chamada/aluno")]
        public IActionResult PostAlunoIsPresent([FromBody] NewChamadaInputModel inputModel)
        {
            if (!_alunoIntegration.AlunoIsPresent(inputModel))
            {
                return NotFound();
            }

            return Ok($"Aluno {inputModel.IdAluno} da Disciplina {inputModel.IdDisciplina} Presente.");
        }

        [HttpPost("/atividade")]
        public IActionResult PostAtividade([FromBody] NewAtividadeInputModel inputModel)
        {
            var id = _atividadeService.Create(inputModel);
            
            if (id == null || id == 0)
            {
                return NotFound();
            }

            return Ok($"Atividade '{inputModel.Nome}' criado com sucesso.");
        }

        [HttpGet("/atividade/professor/{idProfessor}")]
        public IActionResult GetAtividadeAlunoByIdProfessor(int idProfessor)
        {
            var atividadeAlunos = _atividadeAlunosService.GetAtividadesByProfessor(idProfessor);

            return Ok(atividadeAlunos);
        }

        [HttpPost("/atividade/aluno/ponto")]
        public IActionResult PostAtividadeSetPoint([FromBody]UpdateAtividadeAlunoInputModel inputModel)
        {
            _atividadeAlunosService.UpdateNota(inputModel);

            return Ok();
        }
    }
}
