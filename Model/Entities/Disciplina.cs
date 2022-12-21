using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Disciplina : BaseEntity
    {
        public Disciplina(string nome, int idProfessor)
        {
            Nome= nome;
            IdProfessor= idProfessor;
            Alunos = new List<DisciplinaAluno>();
        }
        public string Nome { get; private set; }
        public int IdProfessor { get; private set; }
        public Professor Professor { get; private set; }
        public List<DisciplinaAluno> Alunos { get; private set; }
    }
}
