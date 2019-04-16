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
    public class ContatoController : Controller
    {
        private readonly ContextoGeral _context;

        public ContatoController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Contato
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.Contatos.Include(c => c.Email).Include(c => c.Endereco).Include(c => c.Pessoa).Include(c => c.Telefone);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: Contato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .Include(c => c.Email)
                .Include(c => c.Endereco)
                .Include(c => c.Pessoa)
                .Include(c => c.Telefone)
                .FirstOrDefaultAsync(m => m.ContatoId == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contato/Create
        public IActionResult Create()
        {
            ViewData["EmailId"] = new SelectList(_context.Emails, "EmailId", "EnderecoEmail");
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome");
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Numero");
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContatoId,PessoaId,EmailId,TelefoneId,EnderecoId")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmailId"] = new SelectList(_context.Emails, "EmailId", "EnderecoEmail", contato.EmailId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", contato.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", contato.PessoaId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Numero", contato.TelefoneId);
            return View(contato);
        }

        // GET: Contato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            ViewData["EmailId"] = new SelectList(_context.Emails, "EmailId", "EnderecoEmail", contato.EmailId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", contato.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", contato.PessoaId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Numero", contato.TelefoneId);
            return View(contato);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContatoId,PessoaId,EmailId,TelefoneId,EnderecoId")] Contato contato)
        {
            if (id != contato.ContatoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.ContatoId))
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
            ViewData["EmailId"] = new SelectList(_context.Emails, "EmailId", "EnderecoEmail", contato.EmailId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Bairro", contato.EnderecoId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", contato.PessoaId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "TelefoneId", "Numero", contato.TelefoneId);
            return View(contato);
        }

        // GET: Contato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .Include(c => c.Email)
                .Include(c => c.Endereco)
                .Include(c => c.Pessoa)
                .Include(c => c.Telefone)
                .FirstOrDefaultAsync(m => m.ContatoId == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contatos.Any(e => e.ContatoId == id);
        }
    }
}
