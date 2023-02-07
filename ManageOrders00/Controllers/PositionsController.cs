using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageOrders00.Data;
using ManageOrders00.Models;

namespace ManageOrders00.Controllers
{
    public class PositionsController : Controller
    {
        private readonly ManageOrders00Context _context;

        public PositionsController(ManageOrders00Context context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var manageOrders00Context = _context.Position.Include(p => p.Order).Include(p => p.Product);
            return View(await manageOrders00Context.ToListAsync());
        }

        public async Task<IActionResult> EditForOrders(int? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }
            var manageOrders00Context = _context.Position.Include(p => p.Order).Include(p => p.Product).Where(i => i.OrderId == id);
            return View(await manageOrders00Context.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create(int? id)
        {
            ViewBag.OrderNumber = new { id };
            ViewData["ProductName"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductName");
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionId,OrderId,ProductId,ProductCount")] Position position)
        {
            var positions = _context.Position.Where(r => r.OrderId == position.OrderId).ToList();
            int AvailabilityResult;
            foreach(var i in positions)
            {
                if(i.ProductId == position.ProductId)
                {
                    ModelState.AddModelError("ProductId", "Такий товар вже є у вас в замовленні");
                    ViewBag.OrderNumber = new { id = position.OrderId };
                    ViewData["ProductName"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductName");
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Orders", new { id = position.OrderId });
            }
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", position.ProductId);
            return View(position);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            ViewBag.PositionNum = new {  id };
            ViewBag.ProductId = new { productId = position.ProductId };
            ViewBag.OrderNum = new { p = position.OrderId  };
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionId,OrderId,ProductId,ProductCount")] Position position)
        {
            if (id != position.PositionId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.PositionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","Orders", new { id = position.OrderId });
            }
            ViewBag.PositionNum = new { id };
            ViewBag.OrderNum = new { p = position.OrderId };
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }
            ViewBag.OrderId = new { orderId = position.OrderId };

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Position == null)
            {
                return Problem("Entity set 'ManageOrders00Context.Position'  is null.");
            }
            var position = await _context.Position.FindAsync(id);
            var positionOrderId = position.OrderId;
            if (position != null)
            {
                _context.Position.Remove(position);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = positionOrderId });
        }

        private bool PositionExists(int id)
        {
          return (_context.Position?.Any(e => e.PositionId == id)).GetValueOrDefault();
        }
    }
}
