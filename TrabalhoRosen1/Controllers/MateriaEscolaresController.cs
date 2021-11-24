using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoRosen1.Models;

namespace TrabalhoRosen1.Controllers
{
    public class MateriaEscolaresController : Controller
    {
        private readonly Context _context;

        public MateriaEscolaresController(Context context)
        {
            _context = context;
        }

        // GET: MateriaEscolars
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriaEscolares.ToListAsync());
        }

        // GET: MateriaEscolars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEscolar = await _context.MateriaEscolares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaEscolar == null)
            {
                return NotFound();
            }

            return View(materiaEscolar);
        }

        // GET: MateriaEscolars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaEscolars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] MateriaEscolar materiaEscolar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaEscolar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaEscolar);
        }

        // GET: MateriaEscolars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEscolar = await _context.MateriaEscolares.FindAsync(id);
            if (materiaEscolar == null)
            {
                return NotFound();
            }
            return View(materiaEscolar);
        }

        // POST: MateriaEscolars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] MateriaEscolar materiaEscolar)
        {
            if (id != materiaEscolar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaEscolar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaEscolarExists(materiaEscolar.Id))
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
            return View(materiaEscolar);
        }

        // GET: MateriaEscolars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaEscolar = await _context.MateriaEscolares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaEscolar == null)
            {
                return NotFound();
            }

            return View(materiaEscolar);
        }

        // POST: MateriaEscolars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaEscolar = await _context.MateriaEscolares.FindAsync(id);
            _context.MateriaEscolares.Remove(materiaEscolar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaEscolarExists(int id)
        {
            return _context.MateriaEscolares.Any(e => e.Id == id);
        }
    }
}
