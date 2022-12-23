using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IDisciplinaAlunosService
    {
        List<DisciplinaAlunosViewModel> GetById(int idDisciplina);
        int Create(NewDisciplinaAlunosInputModel inputModel);
        void Delete(int id);
    }
}
