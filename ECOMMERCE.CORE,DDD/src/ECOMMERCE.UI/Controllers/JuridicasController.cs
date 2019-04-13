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
    public class JuridicasController : Controller
    {
        private readonly ContextoGeral _context;

        public JuridicasController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Juridicas
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.Juridica.Include(j => j.PessoaTipo);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Juridicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .Include(j => j.PessoaTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // GET: Juridicas/Create
        public IActionResult Create()
        {
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id");
            return View();
        }

        // POST: Juridicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,DataFundacao,Nome,Sobrenome,DataNascimento,PessoaTipoId,Id")] Juridica juridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", juridica.PessoaTipoId);
            return View(juridica);
        }

        // GET: Juridicas/Edit/5
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
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", juridica.PessoaTipoId);
            return View(juridica);
        }

        // POST: Juridicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeFantasia,RazaoSocial,Cnpj,InscricaoEstadual,DataFundacao,Nome,Sobrenome,DataNascimento,PessoaTipoId,Id")] Juridica juridica)
        {
            if (id != juridica.Id)
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
                    if (!JuridicaExists(juridica.Id))
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
            ViewData["PessoaTipoId"] = new SelectList(_context.PessoaTipo, "Id", "Id", juridica.PessoaTipoId);
            return View(juridica);
        }

        // GET: Juridicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juridica = await _context.Juridica
                .Include(j => j.PessoaTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juridica == null)
            {
                return NotFound();
            }

            return View(juridica);
        }

        // POST: Juridicas/Delete/5
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
            return _context.Juridica.Any(e => e.Id == id);
        }
    }
}
