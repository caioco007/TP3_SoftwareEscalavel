using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class DisciplinaAluno : BaseEntity
    {
        public DisciplinaAluno(int idDisciplina, int idAluno)
        {
            IdDisciplina = idDisciplina;
            IdAluno = idAluno;
        }

        public int IdDisciplina { get; private set; }
        public int IdAluno { get; private set; }
    }
}
