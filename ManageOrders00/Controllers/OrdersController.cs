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
    public class OrdersController : Controller
    {
        private readonly ManageOrders00Context _context;

        public OrdersController(ManageOrders00Context context)
        {
            _context = context;
        }

        // GET: Orders
        /*      public async Task<IActionResult> Index()
              {
                  var manageOrders00Context = _context.Order.Include(o => o.Customer);
                  return View(await manageOrders00Context.ToListAsync());
              }*/

        public async Task<IActionResult> Index(string searchString,DateTime beginOrderReleasDate, DateTime finalOrderReleasDate)
        {
            SelectList customerSurname = new SelectList(_context.Customer.Select(i => i.CustomerSurName));
            SelectList orderReleasDate = new SelectList(_context.Order.Select(i => i.OrderReleaseDate));
            ViewBag.CustomerSurName =  customerSurname;
            ViewBag.OrderReleaseDate = orderReleasDate;
            var orders = from m in _context.Order.Include(o => o.Customer)
                         select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Customer.CustomerSurName.Contains(searchString));
            }
            if (beginOrderReleasDate.Year != 1 && finalOrderReleasDate.Year != 1)
            {
                orders = orders.Where(i => i.OrderReleaseDate > beginOrderReleasDate);
                orders = orders.Where(i => i.OrderReleaseDate <= finalOrderReleasDate);
            }
            else if (beginOrderReleasDate.Year == 1 && finalOrderReleasDate.Year != 1)
            {
                orders = orders.Where(i => i.OrderReleaseDate <= finalOrderReleasDate);
            }
            else if (finalOrderReleasDate.Year == 1 && beginOrderReleasDate.Year != 1)
            {
                orders = orders.Where(i => i.OrderReleaseDate > beginOrderReleasDate);
            }


            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.Positions.Where(i => i.OrderId == id))
                .FirstOrDefaultAsync(m => m.OrderId == id);

            var positionList = order.Positions;
            var productDiteils = await Task.Run(() => _context.Product);
            var productList = new List<Product>();
            foreach (var pos in positionList)
            {
              var prod = productDiteils.FirstOrDefault(i => i.ProductId == pos.ProductId);
                productList.Add(prod);
            }
            


            ViewBag.Product = productList;

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["CustomerSurName"] = new SelectList(_context.Customer, "CustomerId", "CustomerSurName");
            return View();
        }

        // POST: Orders/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,CustomerSurName")] Order order,  int customer)
        {
            order.CustomerId = customer;
            order.OrderReleaseDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new {id = order.OrderId});
            }
            ViewData["CustomerSurName"] = new SelectList(_context.Customer, order.Customer.CustomerSurName);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'ManageOrders00Context.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Order?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
