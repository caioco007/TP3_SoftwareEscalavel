using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class AtividadeAlunosViewModel
    {
        public int Id { get; set; }
        public int IdAtividade { get; set; }
        public string AtividadeNome { get; set; }
        public int IdAluno { get; set; }
        public string AlunoNome { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal? Nota { get; set; }
    }
}
