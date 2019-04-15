using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Contatos;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ContextoGeral _context;

        public TelefoneController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Telefone
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.Telefone.Include(t => t.TelefoneTipo);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Telefone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TelefoneTipo)
                .FirstOrDefaultAsync(m => m.TelefoneId == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefone/Create
        public IActionResult Create()
        {
            ViewData["TelefoneTipoId"] = new SelectList(_context.TelefoneTipo, "TelefoneTipoId", "Descricao");
            return View();
        }

        // POST: Telefone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelefoneId,Numero,TelefoneTipoId")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TelefoneTipoId"] = new SelectList(_context.TelefoneTipo, "TelefoneTipoId", "Descricao", telefone.TelefoneTipoId);
            return View(telefone);
        }

        // GET: Telefone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["TelefoneTipoId"] = new SelectList(_context.TelefoneTipo, "TelefoneTipoId", "Descricao", telefone.TelefoneTipoId);
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelefoneId,Numero,TelefoneTipoId")] Telefone telefone)
        {
            if (id != telefone.TelefoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.TelefoneId))
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
            ViewData["TelefoneTipoId"] = new SelectList(_context.TelefoneTipo, "TelefoneTipoId", "Descricao", telefone.TelefoneTipoId);
            return View(telefone);
        }

        // GET: Telefone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TelefoneTipo)
                .FirstOrDefaultAsync(m => m.TelefoneId == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.Telefone.FindAsync(id);
            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefone.Any(e => e.TelefoneId == id);
        }
    }
}
