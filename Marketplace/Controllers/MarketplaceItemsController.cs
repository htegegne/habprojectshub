using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketplace.Models.Entities;
using Marketplace.Services;

namespace Marketplace.Controllers
{
    public class MarketplaceItemsController : Controller
    {
        private readonly MarketplaceDbContext _context;

        public MarketplaceItemsController(MarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: MarketplaceItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarketplaceItems.ToListAsync());
        }

        // GET: MarketplaceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplaceItem = await _context.MarketplaceItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marketplaceItem == null)
            {
                return NotFound();
            }

            return View(marketplaceItem);
        }

        // GET: MarketplaceItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarketplaceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,Price,SellerName,SellerEmail,DatePosted")] MarketplaceItem marketplaceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marketplaceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marketplaceItem);
        }

        // GET: MarketplaceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplaceItem = await _context.MarketplaceItems.FindAsync(id);
            if (marketplaceItem == null)
            {
                return NotFound();
            }
            return View(marketplaceItem);
        }

        // POST: MarketplaceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,Price,SellerName,SellerEmail,DatePosted")] MarketplaceItem marketplaceItem)
        {
            if (id != marketplaceItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marketplaceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketplaceItemExists(marketplaceItem.Id))
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
            return View(marketplaceItem);
        }

        // GET: MarketplaceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplaceItem = await _context.MarketplaceItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marketplaceItem == null)
            {
                return NotFound();
            }

            return View(marketplaceItem);
        }

        // POST: MarketplaceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marketplaceItem = await _context.MarketplaceItems.FindAsync(id);
            if (marketplaceItem != null)
            {
                _context.MarketplaceItems.Remove(marketplaceItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketplaceItemExists(int id)
        {
            return _context.MarketplaceItems.Any(e => e.Id == id);
        }
    }
}
