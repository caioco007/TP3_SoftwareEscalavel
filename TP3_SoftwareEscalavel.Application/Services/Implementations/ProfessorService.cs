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
        private readonly ProfessorDbContext _dbContext;
        public ProfessorService(ProfessorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewProfessorInputModel inputModel)
        {
            var professor = new Professor(inputModel.Nome);

            _dbContext.Professores.Add(professor);

            return professor.Id;
        }

        public List<ProfessorViewModel> GetAll()
        {
            var professores = _dbContext.Professores;

            var professoresViewModel = professores.Select(p => new ProfessorViewModel(p.Id, p.Nome)).ToList();

            return professoresViewModel;
        }

        public ProfessorViewModel GetById(int id)
        {
            var professor = _dbContext.Professores.SingleOrDefault(p => p.Id == id);

            if (professor == null) return null;

            var professoresViewModel = new ProfessorViewModel(
                professor.Id,
                professor.Nome
                );

            return professoresViewModel;
        }

        public void Delete(int id)
        {
            var professor = _dbContext.Professores.SingleOrDefault(p => p.Id == id);

            _dbContext.Professores.Remove(professor);
        }

        public void Update(UpdateProfessorInputModel inputModel)
        {
            var professor = _dbContext.Professores.SingleOrDefault(p => p.Id == inputModel.Id);

            professor.Update(inputModel.Nome);
        }
    }
}
