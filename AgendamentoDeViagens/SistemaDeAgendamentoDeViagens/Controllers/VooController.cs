using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeAgendamentoDeViagens.Data;
using SistemaDeAgendamentoDeViagens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Controllers
{
    public class VooController : Controller
    {
        private readonly ViagemContext _context;
        public VooController(ViagemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Voos.OrderBy(c => c.VooId).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Origem_voo, Destino_voo, Descricao_voo, Data_partida_voo, Data_chegada_voo, Capacidade_voo")]Voo voo)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(voo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(voo);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos.SingleOrDefaultAsync(m => m.VooId == id);

            if(voo == null)
            {
                return NotFound();
            }
            return View(voo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(long? id, [Bind("ID_voo, Origem_voo, Destino_voo, Descricao_voo, Data_partida_voo, Data_chegada_voo, Capacidade_voo")]Voo voo)
        {
            if(id != voo.VooId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(voo);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!VooExists(voo.VooId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voo);
        }
        public bool VooExists(long? id)
        {
            return _context.Voos.Any(e => e.VooId == id);
        }


        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos.SingleOrDefaultAsync(m => m.VooId == id);

            if(voo == null)
            {
                return NotFound();
            }
            return View(voo);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if(id ==null)
            {
                return NotFound();
            }

            var voo = await _context.Voos.SingleOrDefaultAsync(m => m.VooId == id);

            if(voo ==null)
            {
                return NotFound();
            }
            return View(voo);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var voo = await _context.Voos.SingleOrDefaultAsync(m => m.VooId == id);
            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
