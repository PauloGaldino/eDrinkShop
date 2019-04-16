using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas.Profissoes;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class ProfissaoClienteController : Controller
    {
        private readonly ContextoGeral _context;

        public ProfissaoClienteController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: ProfissaoCliente
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.ProfissaoClientes.Include(p => p.Cliente).Include(p => p.Profissao);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: ProfissaoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoCliente = await _context.ProfissaoClientes
                .Include(p => p.Cliente)
                .Include(p => p.Profissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissaoCliente == null)
            {
                return NotFound();
            }

            return View(profissaoCliente);
        }

        // GET: ProfissaoCliente/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO");
            return View();
        }

        // POST: ProfissaoCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProfissaoId")] ProfissaoCliente profissaoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissaoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", profissaoCliente.ClienteId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoCliente.ProfissaoId);
            return View(profissaoCliente);
        }

        // GET: ProfissaoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoCliente = await _context.ProfissaoClientes.FindAsync(id);
            if (profissaoCliente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", profissaoCliente.ClienteId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoCliente.ProfissaoId);
            return View(profissaoCliente);
        }

        // POST: ProfissaoCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProfissaoId")] ProfissaoCliente profissaoCliente)
        {
            if (id != profissaoCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissaoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissaoClienteExists(profissaoCliente.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", profissaoCliente.ClienteId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoCliente.ProfissaoId);
            return View(profissaoCliente);
        }

        // GET: ProfissaoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoCliente = await _context.ProfissaoClientes
                .Include(p => p.Cliente)
                .Include(p => p.Profissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissaoCliente == null)
            {
                return NotFound();
            }

            return View(profissaoCliente);
        }

        // POST: ProfissaoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissaoCliente = await _context.ProfissaoClientes.FindAsync(id);
            _context.ProfissaoClientes.Remove(profissaoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissaoClienteExists(int id)
        {
            return _context.ProfissaoClientes.Any(e => e.Id == id);
        }
    }
}
