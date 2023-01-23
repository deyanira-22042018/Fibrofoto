using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fibrofoto.Data;
using Fibrofoto.Models;
using Fibrofoto.Configuration;

namespace Fibrofoto.Controllers
{
    public class RetablosController : Controller
    {
        private readonly FibrofotoContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RetablosController(FibrofotoContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Retablos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Retablos.ToListAsync());
        }

        // GET: Retablos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Retablos == null)
            {
                return NotFound();
            }

            var retablos = await _context.Retablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retablos == null)
            {
                return NotFound();
            }

            return View(retablos);
        }

        // GET: Retablos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retablos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,tamaño,price")] Retablos retablos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retablos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retablos);
        }

        // GET: Retablos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Retablos == null)
            {
                return NotFound();
            }

            var retablos = await _context.Retablos.FindAsync(id);
            if (retablos == null)
            {
                return NotFound();
            }
            return View(retablos);
        }

        // POST: Retablos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,tamaño,price")] Retablos retablos)
        {
            if (id != retablos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retablos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetablosExists(retablos.Id))
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
            return View(retablos);
        }

        // GET: Retablos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Retablos == null)
            {
                return NotFound();
            }

            var retablos = await _context.Retablos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retablos == null)
            {
                return NotFound();
            }

            return View(retablos);
        }

        // POST: Retablos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Retablos == null)
            {
                return Problem("Entity set 'FibrofotoContext.Retablos'  is null.");
            }
            var retablos = await _context.Retablos.FindAsync(id);
            if (retablos != null)
            {
                _context.Retablos.Remove(retablos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetablosExists(int id)
        {
          return _context.Retablos.Any(e => e.Id == id);
        }
    }
}
