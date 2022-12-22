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
    public class AlunoService : IAlunoService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public AlunoService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewAlunoInputModel inputModel)
        {
            var aluno = new Aluno(inputModel.Nome);
            _dbContext.Alunos.Add(aluno);
            _dbContext.SaveChanges();
            return aluno.Id;
        }

        public void Delete(int id)
        {
            var alunos = _dbContext.Alunos;

            var aluno = alunos.SingleOrDefault(x => x.Id == id);

            _dbContext.Alunos.Remove(aluno);
            _dbContext.SaveChanges();
        }

        public List<AlunoViewModel> GetAll()
        {
            var alunos = _dbContext.Alunos;

            var alunoViewModel = alunos
                .Select(a => new AlunoViewModel(a.Id, a.Nome))
                .ToList();
            return alunoViewModel;
        }

        public AlunoViewModel GetById(int id)
        {
            var aluno = _dbContext.Alunos.SingleOrDefault(a => a.Id == id);

            if (aluno == null) return null;

            var alunoViewModel = new AlunoViewModel
            (
                aluno.Id,
                aluno.Nome
            );
            return alunoViewModel;
        }

        public void Update(UpdateAlunoInputModel inputModel)
        {
            var aluno = _dbContext.Alunos.SingleOrDefault(a => a.Id == inputModel.Id);

            aluno.Update(inputModel.Nome);
            _dbContext.SaveChanges();
        }
    }

}
