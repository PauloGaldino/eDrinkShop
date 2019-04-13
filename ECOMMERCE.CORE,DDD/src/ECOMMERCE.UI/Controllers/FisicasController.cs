using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.EPessoas;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class FisicasController : Controller
    {
        private readonly ContextoGeral _context;

        public FisicasController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Fisicas
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.Fisica.Include(f => f.PessoaTipo);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Fisicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica
                .Include(f => f.PessoaTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // GET: Fisicas/Create
        public IActionResult Create()
        {
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id");
            return View();
        }

        // POST: Fisicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Rg,Nome,Sobrenome,DataNascimento,PessoaTipoId,Id")] Fisica fisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", fisica.PessoaTipoId);
            return View(fisica);
        }

        // GET: Fisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica.FindAsync(id);
            if (fisica == null)
            {
                return NotFound();
            }
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", fisica.PessoaTipoId);
            return View(fisica);
        }

        // POST: Fisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Rg,Nome,Sobrenome,DataNascimento,PessoaTipoId,Id")] Fisica fisica)
        {
            if (id != fisica.Id)
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
                    if (!FisicaExists(fisica.Id))
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
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", fisica.PessoaTipoId);
            return View(fisica);
        }

        // GET: Fisicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fisica = await _context.Fisica
                .Include(f => f.PessoaTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fisica == null)
            {
                return NotFound();
            }

            return View(fisica);
        }

        // POST: Fisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fisica = await _context.Fisica.FindAsync(id);
            _context.Fisica.Remove(fisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FisicaExists(int id)
        {
            return _context.Fisica.Any(e => e.Id == id);
        }
    }
}
