using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Application.ViewModels
{
    public class ChamadaViewModel
    {
        public ChamadaViewModel(int id, DateTime dataCriacao)
        {
            Id = id;
            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
