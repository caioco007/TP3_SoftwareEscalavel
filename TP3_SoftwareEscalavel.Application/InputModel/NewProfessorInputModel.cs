using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.InputModel
{
    public class NewProfessorInputModel
    {
        public NewProfessorInputModel(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
