using Gouro.WebApp.MVC.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gouro.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("https://localhost:44343/api/identidade/entrar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DesserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DesserializarObjetoResponse<UsuarioRespostaLogin>(response);

        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("https://localhost:44343/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DesserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DesserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
