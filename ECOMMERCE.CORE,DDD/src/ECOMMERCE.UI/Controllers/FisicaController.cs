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
    public class FisicaController : Controller
    {
        private readonly ContextoGeral _context;

        public FisicaController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Fisica
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.PessoaFisica.Include(f => f.Pessoa);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Fisica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.PessoaFisica
                .Include(f => f.Pessoa)
                .FirstOrDefaultAsync(m => m.FisicaId == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // GET: Fisica/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome");
            return View();
        }

        // POST: Fisica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PessoaId,FisicaId,Cpf,Rg,DataNascimento")] Fisica fisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", fisica.PessoaId);
            return View(fisica);
        }

        // GET: Fisica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.PessoaFisica.FindAsync(id);
            if (fisica == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", fisica.PessoaId);
            return View(fisica);
        }

        // POST: Fisica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,FisicaId,Cpf,Rg,DataNascimento")] Fisica fisica)
        {
            if (id != fisica.FisicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FisicaExists(fisica.FisicaId))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", fisica.PessoaId);
            return View(fisica);
        }

        // GET: Fisica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.PessoaFisica
                .Include(f => f.Pessoa)
                .FirstOrDefaultAsync(m => m.FisicaId == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // POST: Fisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisica = await _context.PessoaFisica.FindAsync(id);
            _context.PessoaFisica.Remove(fisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FisicaExists(int id)
        {
            return _context.PessoaFisica.Any(e => e.FisicaId == id);
        }
    }
}
