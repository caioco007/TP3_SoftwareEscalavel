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
    public class AtividadeService : IAtividadeService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public AtividadeService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewAtividadeInputModel inputModel)
        {
            var atividade = new Atividade(inputModel.idDisciplina, inputModel.Nome, inputModel.DataFinalEntrega);
            _dbContext.Atividades.Add(atividade);
            _dbContext.SaveChanges();

            return atividade.Id;
        }

        public void Delete(int id)
        {
            var atividades = _dbContext.Atividades;

            var atividade = atividades.SingleOrDefault(x => x.Id == id);

            _dbContext.Atividades.Remove(atividade);
            _dbContext.SaveChanges();
        }

        public List<AtividadeViewModel> GetAll()
        {
            var atividadeViewModel = (from at in _dbContext.Atividades
                                      join d in _dbContext.Disciplinas on at.IdDisciplina equals d.Id
                                        select new AtividadeViewModel
                                        {
                                            Id = at.Id,
                                            Nome = at.Nome,
                                            IdDisciplina = at.IdDisciplina,
                                            DisciplinaNome = d.Nome,
                                            DataInicioEntrega = at.DataInicioEntrega,
                                            DataFinalEntrega = at.DataFinalEntrega
                                        });

            return atividadeViewModel.ToList();
        }

        public List<AtividadeViewModel> GetByIdAluno(int idAluno)
        {
            var atividadeViewModel = (from at in _dbContext.Atividades
                                      join d in _dbContext.Disciplinas on at.IdDisciplina equals d.Id
                                      join da in _dbContext.DisciplinaAlunos on at.IdDisciplina equals da.IdDisciplina
                                      where da.IdAluno == idAluno
                                      select new AtividadeViewModel
                                      {
                                          Id = at.Id,
                                          Nome = at.Nome,
                                          IdDisciplina = at.IdDisciplina,
                                          DisciplinaNome = d.Nome,
                                          DataInicioEntrega = at.DataInicioEntrega,
                                          DataFinalEntrega = at.DataFinalEntrega
                                      });

            return atividadeViewModel.ToList();
        }

        public AtividadeViewModel GetById(int id)
        {
            var atividadeViewModel = (from at in _dbContext.Atividades
                                      join d in _dbContext.Disciplinas on at.IdDisciplina equals d.Id
                                      where at.Id == id
                                      select new AtividadeViewModel
                                      {
                                          Id = at.Id,
                                          Nome = at.Nome,
                                          IdDisciplina = at.IdDisciplina,
                                          DisciplinaNome = d.Nome,
                                          DataInicioEntrega = at.DataInicioEntrega,
                                          DataFinalEntrega = at.DataFinalEntrega
                                      });

            return atividadeViewModel.FirstOrDefault();
        }

        public void UpdateNota(UpdateAtividadeInputModel inputModel)
        {
            var atividade = _dbContext.Atividades.SingleOrDefault(a => a.Id == inputModel.Id);

            atividade.Update(inputModel.Nome, inputModel.DataFinalEntrega );
            _dbContext.SaveChanges();
        }
    }
}
