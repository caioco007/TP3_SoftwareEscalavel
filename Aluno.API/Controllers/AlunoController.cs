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
        public AlunoController(IAlunoService alunoService, IChamadaService chamadaService)
        {
            _alunoService = alunoService;
            _chamadaService = chamadaService;
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

        [HttpPost("{idAluno}/chamada/presente")]
        public IActionResult PostChamadaIsPresent(int idAluno)
        {
            //_chamadaService.Create(idAluno);

            return Ok($"Aluno {idAluno} presente.");
        }

        [HttpGet("/chamada/{idAluno}")]
        public IActionResult GetChamadaNow(int idAluno)
        {
            //var chamada =  _chamadaService.GetAllByAlunoIdNow(idAluno);

            //if (chamada == null)
            //{
            //    return NotFound();
            //}

            //return Ok(chamada);
            return NotFound();
        }
    }
}
