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
    public class EnderecoClienteController : Controller
    {
        private readonly ContextoGeral _context;

        public EnderecoClienteController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: EnderecoCliente
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.EnderecoClientes.Include(e => e.Cliente).Include(e => e.Endereco);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: EnderecoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoClientes
                .Include(e => e.Cliente)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }

            return View(enderecoCliente);
        }

        // GET: EnderecoCliente/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId");
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro");
            return View();
        }

        // POST: EnderecoCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,EnderecoId")] EnderecoCliente enderecoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", enderecoCliente.EnderecoId);
            return View(enderecoCliente);
        }

        // GET: EnderecoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoClientes.FindAsync(id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", enderecoCliente.EnderecoId);
            return View(enderecoCliente);
        }

        // POST: EnderecoCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,EnderecoId")] EnderecoCliente enderecoCliente)
        {
            if (id != enderecoCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoClienteExists(enderecoCliente.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", enderecoCliente.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", enderecoCliente.EnderecoId);
            return View(enderecoCliente);
        }

        // GET: EnderecoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoCliente = await _context.EnderecoClientes
                .Include(e => e.Cliente)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoCliente == null)
            {
                return NotFound();
            }

            return View(enderecoCliente);
        }

        // POST: EnderecoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enderecoCliente = await _context.EnderecoClientes.FindAsync(id);
            _context.EnderecoClientes.Remove(enderecoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoClienteExists(int id)
        {
            return _context.EnderecoClientes.Any(e => e.Id == id);
        }
    }
}
