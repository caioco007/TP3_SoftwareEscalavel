using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Core.Entities
{
    public class Atividade : BaseEntity
    {
        public Atividade(int idDisciplina, string nome, DateTime dataFinalEntrega)
        {
            IdDisciplina = idDisciplina;
            Nome = nome;
            DataInicioEntrega = DateTime.Now;
            DataFinalEntrega = dataFinalEntrega;
        }

        public int IdDisciplina { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataInicioEntrega { get; private set; }
        public DateTime DataFinalEntrega { get; private set; }

        public void Update(string nome, DateTime dataFinalEntrega)
        {
            Nome = nome;
            DataFinalEntrega = dataFinalEntrega;
        }
    }
}
