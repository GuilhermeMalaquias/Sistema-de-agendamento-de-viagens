using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaDeAgendamentoDeViagens.Data;
using SistemaDeAgendamentoDeViagens.Models;

namespace SistemaDeAgendamentoDeViagens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ViagemContext _context;
        public HomeController(ViagemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Voos.Where(i => i.Top_voo == true).OrderBy(c => c.Descricao_voo).ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
