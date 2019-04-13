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
    public class PessoaTipoController : Controller
    {
        private readonly ContextoGeral _context;

        public PessoaTipoController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: PessoaTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoaTipo.ToListAsync());
        }

        // GET: PessoaTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTipo = await _context.PessoaTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaTipo == null)
            {
                return NotFound();
            }

            return View(pessoaTipo);
        }

        // GET: PessoaTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaTipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id")] PessoaTipo pessoaTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaTipo);
        }

        // GET: PessoaTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTipo = await _context.PessoaTipo.FindAsync(id);
            if (pessoaTipo == null)
            {
                return NotFound();
            }
            return View(pessoaTipo);
        }

        // POST: PessoaTipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id")] PessoaTipo pessoaTipo)
        {
            if (id != pessoaTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaTipoExists(pessoaTipo.Id))
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
            return View(pessoaTipo);
        }

        // GET: PessoaTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaTipo = await _context.PessoaTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaTipo == null)
            {
                return NotFound();
            }

            return View(pessoaTipo);
        }

        // POST: PessoaTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaTipo = await _context.PessoaTipo.FindAsync(id);
            _context.PessoaTipo.Remove(pessoaTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaTipoExists(int id)
        {
            return _context.PessoaTipo.Any(e => e.Id == id);
        }
    }
}
