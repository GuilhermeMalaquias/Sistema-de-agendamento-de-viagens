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
    public class PassageiroController : Controller
    {
        private readonly ViagemContext _context;

        public PassageiroController(ViagemContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passageiros.OrderBy(c => c.Nome_pas).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create ([Bind("Nome_pas, Data_nasc_pas, Sexo_pas, CPF_pas, Passaporte_pas, UF_pas, Cidade_pas, Bairro_pas, CEP_pas, Email_pas")]Passageiro passageiro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(passageiro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir dados.");
            }
            return View(passageiro);
        }

        public async Task<IActionResult>Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var passageiro = await _context.Passageiros.SingleOrDefaultAsync(m => m.PassageiroId == id);
            if(passageiro == null)
            {
                return NotFound();
            }
            return View(passageiro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(long? id, [Bind("ID_pas, Nome_pas, Data_nasc_pas, Sexo_pas, CPF_pas, Passaporte_pas, UF_pas, Cidade_pas, Bairro_pas, CEP_pas, Email_pas")]Passageiro passageiro)
        {
            if(id != passageiro.PassageiroId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(passageiro);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!PassageiroExists(passageiro.PassageiroId))
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
            return View(passageiro);
        }
        public bool PassageiroExists(long? id)
        {
            return _context.Passageiros.Any(e => e.PassageiroId == id);
        }
        
        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            { 
                return NotFound(); 
            }

            var passageiro = await _context.Passageiros.SingleOrDefaultAsync(m => m.PassageiroId == id);

            if(passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros.SingleOrDefaultAsync(m => m.PassageiroId == id);

            if(passageiro == null)
            {
                return NotFound();
            }
            return View(passageiro);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var passageiro = await _context.Passageiros.SingleOrDefaultAsync(m => m.PassageiroId == id);
            _context.Passageiros.Remove(passageiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
