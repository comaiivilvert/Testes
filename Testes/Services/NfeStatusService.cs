using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Testes.Services
{
    /// <summary>
    /// Service responsible for checking the availability of the NFe status service.
    /// </summary>
    public class NfeStatusService
    {
        private const string ServiceUrl = "https://nfe.svrs.rs.gov.br/ws/NfeStatusServico/NfeStatusServico4.asmx";
        private readonly HttpClient _httpClient;

        public NfeStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Calls the NFe status service with the specified UF and environment and returns the HTTP status code.
        /// </summary>
        public async Task<HttpStatusCode> GetStatusCodeAsync(string uf, string ambiente)
        {
            var url = $"{ServiceUrl}?UF={uf}&tpAmb={ambiente}";
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await _httpClient.SendAsync(request);
            return response.StatusCode;
        }

        /// <summary>
        /// Checks if the service is available (HTTP 200 OK) for the provided UF and environment.
        /// </summary>
        public async Task<bool> IsServiceAvailableAsync(string uf, string ambiente)
        {
            try
            {
                var status = await GetStatusCodeAsync(uf, ambiente);
                return status == HttpStatusCode.OK;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
