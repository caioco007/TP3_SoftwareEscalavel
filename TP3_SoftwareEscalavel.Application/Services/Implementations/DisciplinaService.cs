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
    public class DisciplinaService : IDisciplinaService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public DisciplinaService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewDisciplinaInputModel inputModel)
        {
            var disciplina = new Disciplina(inputModel.Nome, inputModel.IdProfessor);
            _dbContext.Disciplinas.Add(disciplina);
            _dbContext.SaveChanges();
            return disciplina.Id;
        }

        public void Delete(int id)
        {
            var disciplinas = _dbContext.Disciplinas;

            var disciplina = disciplinas.SingleOrDefault(x => x.Id == id);

            _dbContext.Disciplinas.Remove(disciplina);
            _dbContext.SaveChanges();
        }

        public List<DisciplinaViewModel> GetAll()
        {
            var disciplinaViewModel = (from d in _dbContext.Disciplinas
                                    join p in _dbContext.Professores on d.IdProfessor equals p.Id
                                    select new DisciplinaViewModel
                                    {
                                        Id = d.Id,
                                        Nome = d.Nome,
                                        IdProfessor = d.IdProfessor,
                                        ProfessorNome = p.Nome
                                    });

            return disciplinaViewModel.ToList();
        }

        public DisciplinaViewModel GetById(int id)
        {
            var disciplinaViewModel = (from d in _dbContext.Disciplinas
                                    join p in _dbContext.Professores on d.IdProfessor equals p.Id
                                    where d.Id == id
                                    select new DisciplinaViewModel
                                    {
                                        Id = d.Id,
                                        Nome = d.Nome,
                                        IdProfessor = d.IdProfessor,
                                        ProfessorNome = p.Nome
                                    });


            return disciplinaViewModel.FirstOrDefault();
        }
    }
}
