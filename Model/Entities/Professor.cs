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
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}
