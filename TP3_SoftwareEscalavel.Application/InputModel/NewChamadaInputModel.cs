﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.InputModel
{
    public class NewChamadaInputModel
    {
        [JsonPropertyName("idAluno")]
        public int IdAluno { get; set; }
        [JsonPropertyName("idDisciplina")]
        public int IdDisciplina { get; set; }
    }
}
