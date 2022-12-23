using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.InputModel
{
    public class UpdateAtividadeAlunoInputModel
    {
        public int Id { get; set; }
        public int? IdAtividade { get; set; }
        public int? IdAluno { get; set; }
        public decimal Nota { get; set; }
    }
}
