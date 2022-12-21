using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IChamadaService
    {
        List<ChamadaViewModel> GetAll();
        ChamadaViewModel GetById(int id);
        //List<ChamadaViewModel> GetAllByAlunoId(int idAluno);
        int Create();
        List<DadosChamada> GetDadosChamada();
        void AlterIsPresent(int idAluno);
        DadosChamada GetAllByAlunoIdNow(int idAluno);
    }
}
