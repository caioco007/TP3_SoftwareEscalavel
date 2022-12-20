using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IAlunoService
    {
        List<AlunoViewModel> GetAll();
        AlunoViewModel GetById(int id);
        void Delete(int id);
        int Create(NewAlunoInputModel inputModel);
        void Update(UpdateAlunoInputModel inputModel);
    }
}
