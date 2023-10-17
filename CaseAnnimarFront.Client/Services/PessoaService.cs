using CaseAnnimarFront.Client.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseAnnimarFront.Client.Services
{
    public class PessoaService : IPessoasService
    {
        private readonly HttpClient _httpClient;

        public PessoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PessoaDataDTO>> FindAllPessoas()
        {
            var response = await _httpClient.GetAsync("https://localhost:7118/api/pessoas");
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            var pessoas = JsonConvert.DeserializeObject<List<PessoaDataDTO>>(jsonResult);

            return pessoas;
        }
    }
}
