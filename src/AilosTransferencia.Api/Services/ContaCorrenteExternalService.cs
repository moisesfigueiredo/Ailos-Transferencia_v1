using AilosTransferencia.Application.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AilosTransferencia.Api.Services
{
    public class ContaCorrenteExternalService
    {
        private readonly HttpClient _httpClient;

        public ContaCorrenteExternalService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<ServiceResult?> GetContaCorrenteCadastradaAtivaAsync(int numero, string accessToken)
        {
            var baseAddress = "http://ailos-contacorrente-api:8080";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            ServiceResult? result = new();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{baseAddress}/ContaCorrente/GetContaCorrenteCadastradaAtiva?numero={numero}");

                response.EnsureSuccessStatusCode(); // Lança uma exceção se o código de status HTTP indicar erro

                // Desserializa a resposta para o DTO esperado
                // Certifique-se de que ContaCorrenteDto é o DTO correto retornado pela sua API
                var jsonResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<ServiceResult>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);

                throw;
            }
        }

        public string ExtrairTokenRequisicao(string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return string.Empty;
            }

            var token = authorizationHeader.Split(' ').LastOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.RawData;
        }

        public int ExtrairNumeroContaCorrenteOrigem(string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return 0;
            }

            var token = authorizationHeader.Split(' ').LastOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                return 0;
            }

            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            var numeroContaClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "ContaCorrente");

            if (numeroContaClaim == null || string.IsNullOrEmpty(numeroContaClaim.Value))
            {
                return 0;
            }

            if (int.TryParse(numeroContaClaim.Value, out int numeroConta))
            {
                return numeroConta;
            }
            return 0;
        }

        public async Task<ServiceResult> VerificaContaDestino(string tokenRequisicao, int numeroContaDestino)
        {
            var result = new ServiceResult();

            try
            {
                if (string.IsNullOrEmpty(tokenRequisicao))
                {
                    result.AddError("Token não informado.");
                    return result;
                }

                var resultadoRequisicao = await GetContaCorrenteCadastradaAtivaAsync(numeroContaDestino, tokenRequisicao);

                if (resultadoRequisicao == null || !(bool)resultadoRequisicao.IsSuccess)
                {
                    result.AddError("Conta destino não localizada ou inativa.");
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return result;
        }
    }
}
