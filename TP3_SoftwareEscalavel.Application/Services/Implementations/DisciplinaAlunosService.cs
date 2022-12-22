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
    public class DisciplinaAlunosService : IDisciplinaAlunosService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public DisciplinaAlunosService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewDisciplinaAlunosInputModel inputModel)
        {
            var disciplinaAlunos = new DisciplinaAluno(inputModel.IdDisciplina, inputModel.IdAluno);
            _dbContext.DisciplinaAlunos.Add(disciplinaAlunos);
            _dbContext.SaveChanges();
            return disciplinaAlunos.Id;
        }

        public void Delete(int id)
        {
            var disciplinaAlunos = _dbContext.DisciplinaAlunos;

            var disciplinaAluno = disciplinaAlunos.SingleOrDefault(x => x.Id == id);

            _dbContext.DisciplinaAlunos.Remove(disciplinaAluno);
            _dbContext.SaveChanges();
        }

        public DisciplinaAlunosViewModel GetById(int id)
        {
            var disciplinaAlunoViewModel = (from da in _dbContext.DisciplinaAlunos
                                       join a in _dbContext.Alunos on da.IdAluno equals a.Id
                                       join d in _dbContext.Disciplinas on da.IdDisciplina equals d.Id
                                            where da.Id == id
                                       select new DisciplinaAlunosViewModel
                                       {
                                           Id = da.Id,
                                           Nome = d.Nome,
                                           IdAluno = da.IdAluno,
                                           AlunoNome= a.Nome
                                       });


            return disciplinaAlunoViewModel.FirstOrDefault();
        }
    }
}
