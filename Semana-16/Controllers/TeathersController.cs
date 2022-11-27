using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semana_16.Data;
using Semana_16.Models;

namespace Semana_16.Controllers
{
    public class TeathersController : Controller
    {
        private readonly Semana_16Context _context;

        public TeathersController(Semana_16Context context)
        {
            _context = context;
        }

        // GET: Teathers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teather.ToListAsync());
        }

        // GET: Teathers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teather = await _context.Teather
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teather == null)
            {
                return NotFound();
            }

            return View(teather);
        }

        // GET: Teathers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teathers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Cinemas,Price")] Teather teather)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teather);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teather);
        }

        // GET: Teathers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teather = await _context.Teather.FindAsync(id);
            if (teather == null)
            {
                return NotFound();
            }
            return View(teather);
        }

        // POST: Teathers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Cinemas,Price")] Teather teather)
        {
            if (id != teather.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teather);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeatherExists(teather.Id))
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
            return View(teather);
        }

        // GET: Teathers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teather = await _context.Teather
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teather == null)
            {
                return NotFound();
            }

            return View(teather);
        }

        // POST: Teathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teather = await _context.Teather.FindAsync(id);
            _context.Teather.Remove(teather);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeatherExists(int id)
        {
            return _context.Teather.Any(e => e.Id == id);
        }
    }
}
