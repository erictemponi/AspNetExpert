using Gouro.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Gouro.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
                return true;

            return false;
        }
    }
}
