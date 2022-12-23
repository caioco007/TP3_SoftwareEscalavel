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
        int Create(NewChamadaInputModel inputModel);
        void Delete(int id);
        List<ChamadaViewModel> GetByDataCriacao(DateTime datacriacao);
    }
}
