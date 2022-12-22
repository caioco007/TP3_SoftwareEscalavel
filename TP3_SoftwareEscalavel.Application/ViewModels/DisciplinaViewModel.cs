using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class DisciplinaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdProfessor { get; set; }
        public string ProfessorNome { get; set; }
    }
}
