using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroCityCr.Models;

namespace AgroCityCr.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Database _context;

        public FornecedorController(Database context)
        {
            _context = context;
        }

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
              return _context.Fornecedores != null ? 
                          View(await _context.Fornecedores.ToListAsync()) :
                          Problem("Entity set 'Database.Fornecedores'  is null.");
        }

        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedores = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedores == null)
            {
                return NotFound();
            }

            return View(fornecedores);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPNJ,Telefone,Email")] Fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedores);
        }

        // GET: Fornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedores = await _context.Fornecedores.FindAsync(id);
            if (fornecedores == null)
            {
                return NotFound();
            }
            return View(fornecedores);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPNJ,Telefone,Email")] Fornecedores fornecedores)
        {
            if (id != fornecedores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedoresExists(fornecedores.Id))
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
            return View(fornecedores);
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedores = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedores == null)
            {
                return NotFound();
            }

            return View(fornecedores);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fornecedores == null)
            {
                return Problem("Entity set 'Database.Fornecedores'  is null.");
            }
            var fornecedores = await _context.Fornecedores.FindAsync(id);
            if (fornecedores != null)
            {
                _context.Fornecedores.Remove(fornecedores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedoresExists(int id)
        {
          return (_context.Fornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
