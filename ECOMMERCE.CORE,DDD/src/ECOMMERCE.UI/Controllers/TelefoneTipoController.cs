using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Contatos;
using Infra.Data.Data.Context;

namespace ECOMMERCE.UI.Controllers
{
    public class TelefoneTipoController : Controller
    {
        private readonly ContextoGeral _context;

        public TelefoneTipoController(ContextoGeral context)
        {
            _context = context;
        }

        // GET: TelefoneTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TelefoneTipo.ToListAsync());
        }

        // GET: TelefoneTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefoneTipo = await _context.TelefoneTipo
                .FirstOrDefaultAsync(m => m.TelefoneTipoId == id);
            if (telefoneTipo == null)
            {
                return NotFound();
            }

            return View(telefoneTipo);
        }

        // GET: TelefoneTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelefoneTipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelefoneTipoId,Descricao")] TelefoneTipo telefoneTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefoneTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefoneTipo);
        }

        // GET: TelefoneTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefoneTipo = await _context.TelefoneTipo.FindAsync(id);
            if (telefoneTipo == null)
            {
                return NotFound();
            }
            return View(telefoneTipo);
        }

        // POST: TelefoneTipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelefoneTipoId,Descricao")] TelefoneTipo telefoneTipo)
        {
            if (id != telefoneTipo.TelefoneTipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefoneTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneTipoExists(telefoneTipo.TelefoneTipoId))
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
            return View(telefoneTipo);
        }

        // GET: TelefoneTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefoneTipo = await _context.TelefoneTipo
                .FirstOrDefaultAsync(m => m.TelefoneTipoId == id);
            if (telefoneTipo == null)
            {
                return NotFound();
            }

            return View(telefoneTipo);
        }

        // POST: TelefoneTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefoneTipo = await _context.TelefoneTipo.FindAsync(id);
            _context.TelefoneTipo.Remove(telefoneTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneTipoExists(int id)
        {
            return _context.TelefoneTipo.Any(e => e.TelefoneTipoId == id);
        }
    }
}
