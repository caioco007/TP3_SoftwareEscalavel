using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Chamada : BaseEntity
    {
        public Chamada(int id, List<DadosChamada> dadosChamadas)
        {
            Id = id;
            DataCriacao = DateTime.Now;
            DadosChamadas = dadosChamadas;
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<DadosChamada> DadosChamadas { get; set; }
    }

    public class DadosChamada
    {
        public DadosChamada(int idAluno, bool isPresent)
        {
            IdAluno = idAluno;
            IsPresent = isPresent;
        }

        public int IdAluno { get; set; }
        public bool IsPresent { get; set; }

        public void Update(bool isPresent)
        {
            IsPresent = isPresent;
        }

    }

}
