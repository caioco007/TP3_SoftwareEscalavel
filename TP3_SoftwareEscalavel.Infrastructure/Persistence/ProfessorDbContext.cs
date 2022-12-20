using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence
{
    public class ProfessorDbContext
    {
        public ProfessorDbContext()
        {
            Professores = new List<Professor>
            {
                new Professor("Cleyton"),
                new Professor("Wesley"),
                new Professor("Leila"),
            };
        }

        public List<Professor> Professores { get; set; }
    }
}
