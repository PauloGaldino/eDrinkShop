using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas.Profissoes;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class ProfissaoController : Controller
    {
        private readonly ContextoGeral _context;

        public ProfissaoController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: Profissao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profissao.ToListAsync());
        }

        // GET: Profissao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissao = await _context.Profissao
                .FirstOrDefaultAsync(m => m.ProfissaoId == id);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        // GET: Profissao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profissao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfissaoId,Nome,Descricao,CBO")] Profissao profissao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profissao);
        }

        // GET: Profissao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissao = await _context.Profissao.FindAsync(id);
            if (profissao == null)
            {
                return NotFound();
            }
            return View(profissao);
        }

        // POST: Profissao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfissaoId,Nome,Descricao,CBO")] Profissao profissao)
        {
            if (id != profissao.ProfissaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissaoExists(profissao.ProfissaoId))
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
            return View(profissao);
        }

        // GET: Profissao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profissao = await _context.Profissao
                .FirstOrDefaultAsync(m => m.ProfissaoId == id);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        // POST: Profissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissao = await _context.Profissao.FindAsync(id);
            _context.Profissao.Remove(profissao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissaoExists(int id)
        {
            return _context.Profissao.Any(e => e.ProfissaoId == id);
        }
    }
}
