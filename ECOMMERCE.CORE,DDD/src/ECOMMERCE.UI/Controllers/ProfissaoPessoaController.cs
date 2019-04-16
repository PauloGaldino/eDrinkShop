using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas.Profissoes;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class ProfissaoPessoaController : Controller
    {
        private readonly ContextoGeral _context;

        public ProfissaoPessoaController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: ProfissaoPessoa
        public async Task<IActionResult> Index()
        {
            var contextoGeral = _context.ProfissaoPessoa.Include(p => p.Pessoa).Include(p => p.Profissao);
            return View(await contextoGeral.ToListAsync());
        }

        // GET: ProfissaoPessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoPessoa = await _context.ProfissaoPessoa
                .Include(p => p.Pessoa)
                .Include(p => p.Profissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissaoPessoa == null)
            {
                return NotFound();
            }

            return View(profissaoPessoa);
        }

        // GET: ProfissaoPessoa/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome");
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO");
            return View();
        }

        // POST: ProfissaoPessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PessoaId,ProfissaoId")] ProfissaoPessoa profissaoPessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissaoPessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", profissaoPessoa.PessoaId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoPessoa.ProfissaoId);
            return View(profissaoPessoa);
        }

        // GET: ProfissaoPessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoPessoa = await _context.ProfissaoPessoa.FindAsync(id);
            if (profissaoPessoa == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", profissaoPessoa.PessoaId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoPessoa.ProfissaoId);
            return View(profissaoPessoa);
        }

        // POST: ProfissaoPessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PessoaId,ProfissaoId")] ProfissaoPessoa profissaoPessoa)
        {
            if (id != profissaoPessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissaoPessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissaoPessoaExists(profissaoPessoa.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", profissaoPessoa.PessoaId);
            ViewData["ProfissaoId"] = new SelectList(_context.Profissao, "ProfissaoId", "CBO", profissaoPessoa.ProfissaoId);
            return View(profissaoPessoa);
        }

        // GET: ProfissaoPessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissaoPessoa = await _context.ProfissaoPessoa
                .Include(p => p.Pessoa)
                .Include(p => p.Profissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissaoPessoa == null)
            {
                return NotFound();
            }

            return View(profissaoPessoa);
        }

        // POST: ProfissaoPessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissaoPessoa = await _context.ProfissaoPessoa.FindAsync(id);
            _context.ProfissaoPessoa.Remove(profissaoPessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissaoPessoaExists(int id)
        {
            return _context.ProfissaoPessoa.Any(e => e.Id == id);
        }
    }
}
