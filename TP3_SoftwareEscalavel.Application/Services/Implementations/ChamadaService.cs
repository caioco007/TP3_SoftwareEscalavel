using Microsoft.EntityFrameworkCore;
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
        private readonly TP3MicrosservicoDbContext _dbContext;
        public ChamadaService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int Create(NewChamadaInputModel inputModel)
        {
            var chamada = new Chamada(inputModel.IdDisciplina, inputModel.IdAluno);
            _dbContext.Chamadas.Add(chamada);
            _dbContext.SaveChanges();
            return chamada.Id;
        }

        public void Delete(int id)
        {
            var chamadas = _dbContext.Chamadas;

            var chamada = chamadas.SingleOrDefault(x => x.Id == id);

            _dbContext.Chamadas.Remove(chamada);
            _dbContext.SaveChanges();   
        }

        public List<ChamadaViewModel> GetAll()
        {
            var chamadaViewModel = (from c in _dbContext.Chamadas
                                    join a in _dbContext.Alunos on c.IdAluno equals a.Id
                                    join d in _dbContext.Disciplinas on c.IdDisciplina equals d.Id
                                    select new ChamadaViewModel
                                    {
                                        Id = c.Id,
                                        DataCriacao= c.DataCriacao,
                                        IdDisciplina = c.IdDisciplina,
                                        DisciplinaNome = d.Nome,
                                        IdAluno = c.IdAluno,
                                        AlunoNome = a.Nome
                                    });

            return chamadaViewModel.ToList();
        }

        public ChamadaViewModel GetById(int id)
        {
            var chamadaViewModel = (from c in _dbContext.Chamadas
                                    join a in _dbContext.Alunos on c.IdAluno equals a.Id
                                    join d in _dbContext.Disciplinas on c.IdDisciplina equals d.Id
                                    where c.Id == id
                                    select new ChamadaViewModel
                                    {
                                        Id = c.Id,
                                        DataCriacao = c.DataCriacao,
                                        IdDisciplina = c.IdDisciplina,
                                        DisciplinaNome = d.Nome,
                                        IdAluno = c.IdAluno,
                                        AlunoNome = a.Nome
                                    });

            return chamadaViewModel.FirstOrDefault();
        }

        public List<ChamadaViewModel> GetByDataCriacao(DateTime datacriacao)
        {
            var chamadaViewModel = (from c in _dbContext.Chamadas
                                    join a in _dbContext.Alunos on c.IdAluno equals a.Id
                                    join d in _dbContext.Disciplinas on c.IdDisciplina equals d.Id
                                    where c.DataCriacao.Date == datacriacao.Date
                                    select new ChamadaViewModel
                                    {
                                        Id = c.Id,
                                        DataCriacao = c.DataCriacao,
                                        IdDisciplina = c.IdDisciplina,
                                        DisciplinaNome = d.Nome,
                                        IdAluno = c.IdAluno,
                                        AlunoNome = a.Nome
                                    });

            return chamadaViewModel.ToList();
        }
    }
}
