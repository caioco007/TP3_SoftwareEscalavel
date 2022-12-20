using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Infrastructure.Persistence
{
    public class ChamadaDbContext
    {
        public ChamadaDbContext()
        {
            Chamadas = new List<Chamada>
            {
                new Chamada
                (   
                    1,
                    new List<DadosChamada>
                    {
                        new DadosChamada(1,false),
                        new DadosChamada(2,false),
                        new DadosChamada(3,false),
                    }
                ),
                new Chamada
                (
                    2,
                    new List<DadosChamada>
                    {
                        new DadosChamada(1,false),
                        new DadosChamada(2,false),
                        new DadosChamada(3,false),
                    }
                ),
                new Chamada
                (
                    3,
                    new List<DadosChamada>
                    {
                        new DadosChamada(1,false),
                        new DadosChamada(2,false),
                        new DadosChamada(3,false),
                    }
                ),
            };
        }

        public List<Chamada> Chamadas { get; set; }
    }
}
