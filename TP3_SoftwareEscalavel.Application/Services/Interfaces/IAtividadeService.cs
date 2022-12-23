using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IAtividadeService
    {
        int Create(NewAtividadeInputModel inputModel);
        void Delete(int id);
        List<AtividadeViewModel> GetAll();
        List<AtividadeViewModel> GetByIdAluno(int idAluno);
        AtividadeViewModel GetById(int id);
        void UpdateNota(UpdateAtividadeInputModel inputModel);
    }
}
