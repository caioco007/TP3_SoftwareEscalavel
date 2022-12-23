using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.Services.Implementations;
using TP3_SoftwareEscalavel.Application.Services.Integration;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;

namespace Disciplina.API.Controllers
{
    [Route("/disciplina")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaAlunosService _disciplinaAlunosService;
        private readonly IDisciplinaService _disciplinaService;
        public DisciplinaController(IDisciplinaAlunosService disciplinaAlunosService, IDisciplinaService disciplinaService)
        {
            _disciplinaAlunosService = disciplinaAlunosService;
            _disciplinaService = disciplinaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var disciplinas = _disciplinaService.GetAll();
            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var disciplina = _disciplinaService.GetById(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return Ok(disciplina);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _disciplinaService.Delete(id);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewDisciplinaInputModel inputModel)
        {
            if (inputModel.Nome.Length > 50)
            {
                return BadRequest();
            }

            var id = _disciplinaService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPost("/disciplinaAluno")]
        public IActionResult PostAluno([FromBody] NewDisciplinaAlunosInputModel inputModel)
        {
            var id = _disciplinaAlunosService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpGet("/disciplinaAluno/{idDisciplina}")]
        public IActionResult DisciplinaAlunoGetById(int idDisciplina)
        {
            var disciplinaAlunos = _disciplinaAlunosService.GetById(idDisciplina);

            return Ok(disciplinaAlunos);
        }

    }
}
