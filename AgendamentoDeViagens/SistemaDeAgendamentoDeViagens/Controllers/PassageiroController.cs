using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeAgendamentoDeViagens.Data;
using SistemaDeAgendamentoDeViagens.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Controllers
{
    public class PassageiroController : Controller
    {
        private readonly ViagemContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PassageiroController(ViagemContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
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
        public async Task<IActionResult>Create(PassageiroViewModel passageiro)
        {
            if (ModelState.IsValid)
            {
                string nomeUnicoArquivo = Uploadedfile(passageiro);
                Passageiro pass = new Passageiro
                {
                    Nome_pas = passageiro.Nome_pas,
                    Data_nasc_pas = passageiro.Data_nasc_pas,
                    Sexo_pas = passageiro.Sexo_pas,
                    CPF_pas = passageiro.CPF_pas,
                    Passaporte_pas = passageiro.Passaporte_pas,
                    UF_pas = passageiro.UF_pas,
                    Cidade_pas = passageiro.Cidade_pas,
                    Bairro_pas = passageiro.Bairro_pas,
                    CEP_pas = passageiro.CEP_pas,
                    Email_pas = passageiro.Email_pas,
                    Foto_pas = nomeUnicoArquivo,
                };
                _context.Add(pass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passageiro);
        }
           
           
        private string Uploadedfile(PassageiroViewModel passageiro)
        {
            string nomeUnicoArquivo = null;
            if (passageiro.Foto_pas != null)
            {
                string pastasFotos = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens/Passageiro");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + passageiro.Foto_pas.FileName;
                string caminhoArquivo = Path.Combine(pastasFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    passageiro.Foto_pas.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
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
        public async Task<IActionResult>Edit(long? id, [Bind("PassageiroId, Nome_pas, Data_nasc_pas, Sexo_pas, CPF_pas, Passaporte_pas, UF_pas, Cidade_pas, Bairro_pas, CEP_pas, Email_pas")]Passageiro passageiro)
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
