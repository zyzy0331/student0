#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student0.Data;
using student0.Models;

namespace student0.Controllers
{
    public class student1Controller : Controller
    {
        private readonly student0Context _context;

        public student1Controller(student0Context context)
        {
            _context = context;
        }

        // GET: student1
        public async Task<IActionResult> Index()
        {
            return View(await _context.student1.ToListAsync());
        }

        // GET: student1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student1 = await _context.student1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student1 == null)
            {
                return NotFound();
            }

            return View(student1);
        }

        // GET: student1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: student1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nameuse,Gender,Age,Brith,phon,Tem,Datetime")] student1 student1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student1);
        }

        // GET: student1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student1 = await _context.student1.FindAsync(id);
            if (student1 == null)
            {
                return NotFound();
            }
            return View(student1);
        }

        // POST: student1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nameuse,Gender,Age,Brith,phon,Tem,Datetime")] student1 student1)
        {
            if (id != student1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!student1Exists(student1.Id))
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
            return View(student1);
        }

        // GET: student1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student1 = await _context.student1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student1 == null)
            {
                return NotFound();
            }

            return View(student1);
        }

        // POST: student1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student1 = await _context.student1.FindAsync(id);
            _context.student1.Remove(student1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool student1Exists(int id)
        {
            return _context.student1.Any(e => e.Id == id);
        }
    }
}
