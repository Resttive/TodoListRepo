using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class SingleTaskModelsController : Controller
    {
        private readonly SingleTaskContext _context;

        public SingleTaskModelsController(SingleTaskContext context)
        {
            _context = context;
        }

        // GET: SingleTaskModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SingleTaskModel.ToListAsync());
        }

        // GET: SingleTaskModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTaskModel = await _context.SingleTaskModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singleTaskModel == null)
            {
                return NotFound();
            }

            return View(singleTaskModel);
        }

        // GET: SingleTaskModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SingleTaskModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Checkbox,Name,Descript")] SingleTaskModel singleTaskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singleTaskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singleTaskModel);
        }

        // GET: SingleTaskModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTaskModel = await _context.SingleTaskModel.FindAsync(id);
            if (singleTaskModel == null)
            {
                return NotFound();
            }
            return View(singleTaskModel);
        }

        // POST: SingleTaskModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Checkbox,Name,Descript")] SingleTaskModel singleTaskModel)
        {
            if (id != singleTaskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singleTaskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingleTaskModelExists(singleTaskModel.Id))
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
            return View(singleTaskModel);
        }

        // GET: SingleTaskModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singleTaskModel = await _context.SingleTaskModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (singleTaskModel == null)
            {
                return NotFound();
            }

            return View(singleTaskModel);
        }

        // POST: SingleTaskModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singleTaskModel = await _context.SingleTaskModel.FindAsync(id);
            _context.SingleTaskModel.Remove(singleTaskModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingleTaskModelExists(int id)
        {
            return _context.SingleTaskModel.Any(e => e.Id == id);
        }
    }
}
