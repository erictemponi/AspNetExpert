using Gouro.WebApp.MVC.Extensions;
using Gouro.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gouro.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("/api/identidade/entrar", loginContent);

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

            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

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
