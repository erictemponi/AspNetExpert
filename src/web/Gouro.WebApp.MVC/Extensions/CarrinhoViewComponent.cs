﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gouro.WebApp.MVC.Services;

namespace Gouro.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _carrinhoService;

        public CarrinhoViewComponent(IComprasBffService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterQuantidadeCarrinho());
        }
    }
}