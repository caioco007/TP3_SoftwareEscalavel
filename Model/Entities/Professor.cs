using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Professor : BaseEntity
    {
        public Professor(string nome)
        {
            Nome = nome;
            Disciplinas = new List<Disciplina>();
        }
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}
