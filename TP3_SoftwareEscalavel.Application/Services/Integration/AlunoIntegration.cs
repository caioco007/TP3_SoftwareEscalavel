using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SoftwareEscalavel.Application.Services.Integration
{
    public class AlunoIntegration : IAlunoIntegration
    {
        public bool AlunoIsPresent(int idAluno)
        {
            try
            {
                var client = new RestClient($"https://localhost:7236/aluno/{idAluno}/chamada/presente");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);

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
