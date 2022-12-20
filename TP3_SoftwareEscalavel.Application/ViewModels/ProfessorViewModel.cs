using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
