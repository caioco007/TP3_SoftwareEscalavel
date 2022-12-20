using Microsoft.AspNetCore.Mvc;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;

namespace Aluno.API.Controllers
{
    [Route("/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _alunoService.GetAll();

            return Ok(projects);
        }
    }
}
