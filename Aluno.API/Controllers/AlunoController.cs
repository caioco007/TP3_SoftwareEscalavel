using Microsoft.AspNetCore.Mvc;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;

namespace Aluno.API.Controllers
{
    [Route("/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IChamadaService _chamadaService;
        private readonly IAtividadeService _atividadeService;
        private readonly IAtividadeAlunosService _atividadeAlunosService;
        public AlunoController(IAlunoService alunoService, IChamadaService chamadaService, IAtividadeService atividadeService, IAtividadeAlunosService atividadeAlunosService)
        {
            _alunoService = alunoService;
            _chamadaService = chamadaService;
            _atividadeService = atividadeService;
            _atividadeAlunosService = atividadeAlunosService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alunos = _alunoService.GetAll();

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _alunoService.GetById(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _alunoService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewAlunoInputModel inputModel)
        {
            if (inputModel.Nome.Length > 50)
            {
                return BadRequest();
            }

            var id = _alunoService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateAlunoInputModel inputModel)
        {
            if (inputModel.Nome.Length > 50)
            {
                return BadRequest();
            }

            _alunoService.Update(inputModel);

            return NoContent();
        }

        [HttpPost("/chamada/presente")]
        public IActionResult PostChamadaIsPresent([FromBody] NewChamadaInputModel inputModel)
        {
            _chamadaService.Create(inputModel);

            return Ok($"Aluno {inputModel.IdAluno} presente.");
        }

        [HttpPost("/atividade/aluno")]
        public IActionResult PostAtividadeAluno([FromBody] NewAtividadeAlunoInputModel inputModel)
        {
            _atividadeAlunosService.Create(inputModel);

            return Ok($"Aluno {inputModel.IdAluno} entregou a ativide {inputModel.IdAtividade}.");
        }

        [HttpGet("/atividade/aluno/{idAluno}")]
        public IActionResult GetAtividadeByIdAluno(int idAluno)
        {
            var atividades = _atividadeService.GetByIdAluno(idAluno);

            return Ok(atividades);
        }

        [HttpGet("/atividade/{idAtividade}/aluno/{idAluno}")]
        public IActionResult GetAtividadeAluno(int idAtividade, int idAluno)
        {
            var atividade = _atividadeAlunosService.GetByIdAlunoAndIdAtividade(idAtividade, idAluno);

            return Ok(atividade);
        }
    }
}
