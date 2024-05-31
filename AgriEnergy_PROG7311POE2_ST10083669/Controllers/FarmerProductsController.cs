using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergy_PROG7311POE2_ST10083669.Models;

namespace AgriEnergy_PROG7311POE2_ST10083669.Controllers
{
    public class FarmerProductsController : Controller
    {
        private readonly AgriEnergyConnectPlatformContext _context;

        public FarmerProductsController(AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        // GET: FarmerProducts
        public async Task<IActionResult> Index()
        {
            var agriEnergyConnectPlatformContext = _context.FarmerProducts.Include(f => f.Farmer);
            return View(await agriEnergyConnectPlatformContext.ToListAsync());
        }

        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId");
            return View();
        }

        // POST: FarmerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,FarmerId,ProductName,Category,Description,Price,QuantityAvailable,DateAdded")] FarmerProduct farmerProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmerProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", farmerProduct.FarmerId);
            return View(farmerProduct);
        }

        // GET: FarmerProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct == null)
            {
                return NotFound();
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", farmerProduct.FarmerId);
            return View(farmerProduct);
        }

        // POST: FarmerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,FarmerId,ProductName,Category,Description,Price,QuantityAvailable,DateAdded")] FarmerProduct farmerProduct)
        {
            if (id != farmerProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerProductExists(farmerProduct.ProductId))
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
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", farmerProduct.FarmerId);
            return View(farmerProduct);
        }

        // GET: FarmerProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

            return View(farmerProduct);
        }

        // POST: FarmerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct != null)
            {
                _context.FarmerProducts.Remove(farmerProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerProductExists(int id)
        {
            return _context.FarmerProducts.Any(e => e.ProductId == id);
        }
    }
}
