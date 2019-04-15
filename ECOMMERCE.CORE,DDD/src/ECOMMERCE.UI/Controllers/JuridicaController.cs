using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class JuridicaController : Controller
    {
        private readonly ContextoGeral _context;

        public JuridicaController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Juridica
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.Juridica.Include(j => j.Pessoa);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Juridica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .Include(j => j.Pessoa)
                .FirstOrDefaultAsync(m => m.JuridicaId == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // GET: Juridica/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome");
            return View();
        }

        // POST: Juridica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,JuridicaId,NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,DataFundacao")] Juridica juridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", juridica.PessoaId);
            return View(juridica);
        }

        // GET: Juridica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica.FindAsync(id);
            if (juridica == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", juridica.PessoaId);
            return View(juridica);
        }

        // POST: Juridica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,JuridicaId,NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,DataFundacao")] Juridica juridica)
        {
            if (id != juridica.JuridicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuridicaExists(juridica.JuridicaId))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", juridica.PessoaId);
            return View(juridica);
        }

        // GET: Juridica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .Include(j => j.Pessoa)
                .FirstOrDefaultAsync(m => m.JuridicaId == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // POST: Juridica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juridica = await _context.Juridica.FindAsync(id);
            _context.Juridica.Remove(juridica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuridicaExists(int id)
        {
            return _context.Juridica.Any(e => e.JuridicaId == id);
        }
    }
}
