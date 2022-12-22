using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class AtividadeAluno : BaseEntity
    {
        public AtividadeAluno(int idAtividade, int idAluno) 
        {
            IdAtividade = idAtividade;
            IdAluno = idAluno;
            DataEntrega = DateTime.Now;
        }

        public int IdAtividade { get; set; }
        public int IdAluno { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal? Nota { get; set;}

        public void SetNota(decimal nota)
        {
            Nota = nota;
        }
    }
}
