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
        private readonly AlunoDbContext _dbContext;
        public AlunoService(AlunoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewAlunoInputModel inputModel)
        {
            var aluno = new Aluno(inputModel.Id, inputModel.Nome);

            _dbContext.Alunos.Add(aluno);

            return aluno.Id;
        }

        public List<AlunoViewModel> GetAll()
        {
            var alunos = _dbContext.Alunos;

            var alunosViewModel = alunos.Select(p => new AlunoViewModel(p.Id, p.Nome)).ToList();

            return alunosViewModel;
        }

        public AlunoViewModel GetById(int id)
        {
            var aluno = _dbContext.Alunos.SingleOrDefault(p => p.Id == id);

            if (aluno == null) return null;

            var alunosViewModel = new AlunoViewModel(
                aluno.Id,
                aluno.Nome
                );

            return alunosViewModel;
        }

        public void Delete(int id)
        {
            var aluno = _dbContext.Alunos.SingleOrDefault(p => p.Id == id);

            _dbContext.Alunos.Remove(aluno);
        }

        public void Update(UpdateAlunoInputModel inputModel)
        {
            var aluno = _dbContext.Alunos.SingleOrDefault(p => p.Id == inputModel.Id);

            aluno.Update(inputModel.Nome);
        }
    }
}
