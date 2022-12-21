using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Aluno : BaseEntity
    {
        public Aluno(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}
