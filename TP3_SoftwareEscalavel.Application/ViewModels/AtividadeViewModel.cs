using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class AtividadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdDisciplina { get; set; }
        public string DisciplinaNome { get; set; }
        public DateTime DataInicioEntrega { get; set; }
        public DateTime DataFinalEntrega { get; set; }
    }
}
