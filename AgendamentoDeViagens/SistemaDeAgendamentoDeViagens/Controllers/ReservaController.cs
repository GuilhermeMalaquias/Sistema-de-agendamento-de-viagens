using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeAgendamentoDeViagens.Data;
using SistemaDeAgendamentoDeViagens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ViagemContext _context;
        public ReservaController (ViagemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.Include(p => p.Passageiro).Include(v => v.Voo).OrderBy(r => r.ReservaId).ToListAsync());
        }

        public IActionResult Create()
        {
            var passageiros = _context.Passageiros.OrderBy(i => i.Passaporte_pas).ToList();
            passageiros.Insert(0, new Passageiro() { PassageiroId = 0, Passaporte_pas = "[Selecione o passageiro]"});
            ViewBag.Passageiros = passageiros;

            var voos = _context.Voos.OrderBy(i => i.Destino_voo).ToList();
            voos.Insert(0, new Voo() {VooId = 0, Destino_voo = "[Selecione o Destino]"});
            ViewBag.Voos = voos;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Data_res, Linha_aer_res, Preco_res, PassageiroId, VooId")] Reserva reserva)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(reserva);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.SingleOrDefaultAsync(m => m.ReservaId == id);

            if(reserva == null)
            {
                return NotFound();
            }
            ViewBag.Passageiros = new SelectList(_context.Passageiros.OrderBy(i => i.Passaporte_pas), "PassageiroId", "Passaporte_pas", reserva.PassageiroId);
            ViewBag.Voos = new SelectList(_context.Voos.OrderBy(i => i.Destino_voo), "VooId", "Destino_voo", reserva.VooId);
            return View(reserva);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ReservaId, Data_res, Linha_aer_res, Preco_res, PassageiroId, VooId")]Reserva reserva)
        {
            if(id != reserva.ReservaId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!ReservaExists(reserva.ReservaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Passageiros = new SelectList(_context.Passageiros.OrderBy(i => i.Passaporte_pas), "PassageiroId", "Passaporte_pas", reserva.PassageiroId);
                ViewBag.Voos = new SelectList(_context.Voos.OrderBy(i => i.Destino_voo), "VooId", "Destino_voo", reserva.VooId);
                return RedirectToAction(nameof(Index));
            }
           
            return View(reserva);
        }

        public bool ReservaExists(long? id)
        {
            return _context.Passageiros.Any(e => e.PassageiroId == id);
        }


        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.SingleOrDefaultAsync(m => m.ReservaId == id);

            _context.Passageiros.Where(i => reserva.PassageiroId == i.PassageiroId).Load();
            _context.Voos.Where(i => reserva.VooId == i.VooId).Load();

            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.SingleOrDefaultAsync(m => m.ReservaId == id);

            if(reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var reserva = await _context.Reservas.SingleOrDefaultAsync(m => m.ReservaId == id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
