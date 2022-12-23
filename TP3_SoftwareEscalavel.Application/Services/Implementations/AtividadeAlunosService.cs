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
    public class AtividadeAlunosService : IAtividadeAlunosService
    {
        private readonly TP3MicrosservicoDbContext _dbContext;
        public AtividadeAlunosService(TP3MicrosservicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public int Create(NewAtividadeAlunoInputModel inputModel)
        {
            var atividadeAluno = new AtividadeAluno(inputModel.IdAtividade, inputModel.IdAluno);
            _dbContext.AtividadeAlunos.Add(atividadeAluno);
            _dbContext.SaveChanges();

            return atividadeAluno.Id;
        }
        public void Delete(int id)
        {
            var atividadeAlunos = _dbContext.AtividadeAlunos;

            var atividadeAluno = atividadeAlunos.SingleOrDefault(x => x.Id == id);

            _dbContext.AtividadeAlunos.Remove(atividadeAluno);
            _dbContext.SaveChanges();
        }
        public List<AtividadeAlunosViewModel> GetAll()
        {
            var atividadeAlunosViewModel = (from aa in _dbContext.AtividadeAlunos
                                    join at in _dbContext.Atividades on aa.IdAtividade equals at.Id
                                    join al in _dbContext.Alunos on aa.IdAluno equals al.Id
                                    select new AtividadeAlunosViewModel
                                    {
                                        Id = aa.Id,
                                        IdAtividade = aa.IdAtividade,
                                        AtividadeNome = at.Nome,
                                        IdAluno = aa.IdAluno,
                                        AlunoNome = al.Nome,
                                        DataEntrega = aa.DataEntrega,
                                        Nota = aa.Nota
                                    });

            return atividadeAlunosViewModel.ToList();
        }

        public List<AtividadeAlunosViewModel> GetAtividadesByProfessor(int idProfessor)
        {
            var atividadeAlunosViewModel = (from aa in _dbContext.AtividadeAlunos
                                            join at in _dbContext.Atividades on aa.IdAtividade equals at.Id
                                            join al in _dbContext.Alunos on aa.IdAluno equals al.Id
                                            join d in _dbContext.Disciplinas on at.IdDisciplina equals d.Id
                                            where d.IdProfessor== idProfessor
                                            select new AtividadeAlunosViewModel
                                            {
                                                Id = aa.Id,
                                                IdAtividade = aa.IdAtividade,
                                                AtividadeNome = at.Nome,
                                                IdAluno = aa.IdAluno,
                                                AlunoNome = al.Nome,
                                                DataEntrega = aa.DataEntrega,
                                                Nota = aa.Nota
                                            });

            return atividadeAlunosViewModel.ToList();
        }
        public AtividadeAlunosViewModel GetById(int id)
        {
            var chamadaViewModel = (from aa in _dbContext.AtividadeAlunos
                                    join at in _dbContext.Atividades on aa.IdAtividade equals at.Id
                                    join al in _dbContext.Alunos on aa.IdAluno equals al.Id
                                    where aa.Id == id
                                    select new AtividadeAlunosViewModel
                                    {
                                        Id = aa.Id,
                                        IdAtividade = aa.IdAtividade,
                                        AtividadeNome = at.Nome,
                                        IdAluno = aa.IdAluno,
                                        AlunoNome = al.Nome,
                                        DataEntrega = aa.DataEntrega,
                                         Nota = aa.Nota
                                    });

            return chamadaViewModel.FirstOrDefault();
        }

        public AtividadeAlunosViewModel GetByIdAlunoAndIdAtividade(int idAtividade, int idAluno)
        {
            var chamadaViewModel = (from aa in _dbContext.AtividadeAlunos
                                    join at in _dbContext.Atividades on aa.IdAtividade equals at.Id
                                    join al in _dbContext.Alunos on aa.IdAluno equals al.Id
                                    where aa.IdAtividade == idAtividade && aa.IdAluno == idAluno
                                    select new AtividadeAlunosViewModel
                                    {
                                        Id = aa.Id,
                                        IdAtividade = aa.IdAtividade,
                                        AtividadeNome = at.Nome,
                                        IdAluno = aa.IdAluno,
                                        AlunoNome = al.Nome,
                                        DataEntrega = aa.DataEntrega,
                                        Nota = aa.Nota
                                    });

            return chamadaViewModel.FirstOrDefault();
        }

        public void UpdateNota(UpdateAtividadeAlunoInputModel inputModel)
        {
            var atividadeAluno = _dbContext.AtividadeAlunos.SingleOrDefault(a => a.Id == inputModel.Id);

            atividadeAluno.SetNota(inputModel.Nota);
            _dbContext.SaveChanges();
        }
    }
}
