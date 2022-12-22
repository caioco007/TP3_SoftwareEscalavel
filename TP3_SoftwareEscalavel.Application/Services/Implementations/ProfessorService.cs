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
    public class ProfessorService : IProfessorService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public ProfessorService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProfessorInputModel inputModel)
        {
            var professor = new Professor(inputModel.Nome);
            _dbContext.Professores.Add(professor);
            _dbContext.SaveChanges();
            return professor.Id;
        }

        public void Delete(int id)
        {
            var professores = _dbContext.Professores;

            var professor = professores.SingleOrDefault(x => x.Id == id);

            _dbContext.Professores.Remove(professor);
            _dbContext.SaveChanges();
        }

        public List<ProfessorViewModel> GetAll()
        {
            var professores = _dbContext.Professores;

            var professorViewModel = professores
                .Select(a => new ProfessorViewModel(a.Id, a.Nome))
                .ToList();
            return professorViewModel;
        }

        public ProfessorViewModel GetById(int id)
        {
            var professor = _dbContext.Professores.SingleOrDefault(p => p.Id == id);

            if (professor == null) return null;

            var professorViewModel = new ProfessorViewModel
            (
                professor.Id,
                professor.Nome
            );
            return professorViewModel;
        }

        public void Update(UpdateProfessorInputModel inputModel)
        {
            var professor = _dbContext.Professores.SingleOrDefault(a => a.Id == inputModel.Id);

            professor.Update(inputModel.Nome);
            _dbContext.SaveChanges();
        }
    }
}
