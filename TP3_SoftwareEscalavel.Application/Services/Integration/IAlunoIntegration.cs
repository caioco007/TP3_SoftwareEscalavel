using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;

namespace TP3_SoftwareEscalavel.Application.Services.Integration
{
    public interface IAlunoIntegration
    {
        bool AlunoIsPresent(NewChamadaInputModel inputModel);
    }
}
