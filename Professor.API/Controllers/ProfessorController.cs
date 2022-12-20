using Microsoft.AspNetCore.Mvc;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.Services.Implementations;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;

namespace Professor.API.Controllers
{
    [Route("/professor")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IChamadaService _chamadaService;
        public ProfessorController(IProfessorService professorService, IChamadaService chamadaService)
        {
            _professorService = professorService;
            _chamadaService = chamadaService;
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

        [HttpPost("/chamada")]
        public IActionResult PostChamada()
        {
            var id = _chamadaService.Create();

            return RedirectToAction(nameof(GetChamadaById), new { id = id });
        }

        [HttpGet("/chamada/{id}")]
        public IActionResult GetChamadaById(int id)
        {
            var chamada = _chamadaService.GetById(id);

            if (chamada == null)
            {
                return NotFound();
            }

            return Ok(chamada);
        }

        
    }
}
