using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP3_SoftwareEscalavel.Application.InputModel;
using TP3_SoftwareEscalavel.Core.Entities;

namespace TP3_SoftwareEscalavel.Application.Services.Integration
{
    public class AlunoIntegration : IAlunoIntegration
    {
        public bool AlunoIsPresent(NewChamadaInputModel inputModel)
        {
            try
            {
                var client = new RestClient($"https://localhost:7236/chamada/presente");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonSerializer.Serialize(inputModel);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
