using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence
{
    public class AlunoDbContext
    {
        public AlunoDbContext()
        {
            Alunos = new List<Aluno>
            {
                new Aluno(1, "Caio"),
                new Aluno(2, "Amanda"),
                new Aluno(3, "Shakira")
            };
        }

        public List<Aluno> Alunos { get; set; }
    }
}
