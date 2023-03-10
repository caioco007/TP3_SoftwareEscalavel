using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Chamada : BaseEntity
    {
        public Chamada(int idDisciplina, int idAluno)
        {
            DataCriacao = DateTime.Now;
            IdDisciplina= idDisciplina;
            IdAluno= idAluno;
        }

        public DateTime DataCriacao { get; private set; }
        public int IdDisciplina { get; private set; }
        public int IdAluno { get; private set; }
    }

    
}
