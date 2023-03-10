using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class ChamadaViewModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int IdAluno { get; set; }
        public string AlunoNome { get; set; }
        public int IdDisciplina { get; set; }
        public string DisciplinaNome { get; set; }
    }
}
