using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Application.ViewModels;

namespace TP3_SoftwareEscalavel.Application.Services.Interfaces
{
    public interface IProfessorService
    {
        List<ProfessorViewModel> GetAll();
        ProfessorViewModel GetById(int id);
        void Delete(int id);
        int Create(NewProfessorInputModel inputModel);
        void Update(UpdateProfessorInputModel inputModel);
    }
}
