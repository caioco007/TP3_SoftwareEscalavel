using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IAtividadeAlunosService
    {
        int Create(NewAtividadeAlunoInputModel inputModel);
        void Delete(int id);
        List<AtividadeAlunosViewModel> GetAll();
        List<AtividadeAlunosViewModel> GetAtividadesByProfessor(int idProfessor);
        AtividadeAlunosViewModel GetByIdAlunoAndIdAtividade(int idAtividade, int idAluno);
        AtividadeAlunosViewModel GetById(int id);
        void UpdateNota(UpdateAtividadeAlunoInputModel inputModel);
    }
}
