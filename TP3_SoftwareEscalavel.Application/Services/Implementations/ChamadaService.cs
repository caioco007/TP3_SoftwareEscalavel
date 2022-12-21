using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;
using TP3_SoftwareEscalavel.Application.ViewModels;
using TP3_SoftwareEscalavel.Core.Entities;
using TP3_SoftwareEscalavel.Infrastructure.Persistence;

namespace TP3_SoftwareEscalavel.Application.Services.Implementations
{
    public class ChamadaService : IChamadaService
    {
        private readonly ChamadaDbContext _dbContext;
        private readonly IAlunoService _alunoService;
        public ChamadaService(ChamadaDbContext dbContext, IAlunoService alunoService)
        {
            _dbContext = dbContext;
            _alunoService = alunoService;
        }

        public List<ChamadaViewModel> GetAll()
        {
            var chamadas = _dbContext.Chamadas;

            var chamadasViewModel = chamadas.Select(p => new ChamadaViewModel(p.Id, p.DataCriacao, p.DadosChamadas)).ToList();

            return chamadasViewModel;
        }

        public ChamadaViewModel GetById(int id)
        {
            var chamada = _dbContext.Chamadas.SingleOrDefault(p => p.Id == id);

            if (chamada == null) return null;

            var chamadasViewModel = new ChamadaViewModel(
                chamada.Id,
                chamada.DataCriacao,
                chamada.DadosChamadas
                );

            return chamadasViewModel;
        }

        //public List<ChamadaViewModel> GetAllByAlunoId(int idAluno)
        //{
        //    var chamadasViewModel = _dbContext.Chamadas.Where(p => p.IdAluno == idAluno).Select(x => new ChamadaViewModel(x.Id, x.IdAluno, x.IsPresent)).ToList();

        //    if (chamadasViewModel == null) return null;

        //    return chamadasViewModel;
        //}

        public DadosChamada GetAllByAlunoIdNow(int idAluno)
        {
            var dadosChamadas = _dbContext.Chamadas.FirstOrDefault(p => p.DataCriacao.Date == DateTime.Now.Date).DadosChamadas;
            //var dadosChamadas = _dbContext.Chamadas.SingleOrDefault(p => p.DataCriacao.Date == DateTime.Now.Date).DadosChamadas;

            var aluno = dadosChamadas.SingleOrDefault(x => x.IdAluno == idAluno);

            return aluno;
        }

        public int Create()
        {
            int id = _dbContext.Chamadas.Select(x => x.Id).Max();
            int idChamada = id + 1;

            var chamada = new Chamada(idChamada, GetDadosChamada());
            _dbContext.Chamadas.Add(chamada);

            return idChamada;

        }

        public List<DadosChamada> GetDadosChamada()
        {
            var alunos = _alunoService.GetAll();
            List<DadosChamada> dadosChamadas = new List<DadosChamada>();
            foreach (var aluno in alunos)
            {
                dadosChamadas.Add(new DadosChamada(aluno.Id, false));
            }

            return dadosChamadas;
        }

        public void AlterIsPresent(int idAluno)
        {
            var dadosChamadas = _dbContext.Chamadas.FirstOrDefault(p => p.DataCriacao.Date == DateTime.Now.Date).DadosChamadas;

            var aluno = dadosChamadas.SingleOrDefault(x => x.IdAluno == idAluno);

            aluno.UpdateIsPresent(true);
        }

    }
}
