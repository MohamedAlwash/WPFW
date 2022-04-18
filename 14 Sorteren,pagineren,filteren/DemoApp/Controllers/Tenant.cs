#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoApp.Data;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class TenantController : Controller
    {
        private readonly MyDbContext _context;

        public TenantController(MyDbContext context)
        {
            _context = context;
        }

        public IQueryable<Tenant> Sorteer(IQueryable<Tenant> lijst, string sorteer)
        {
            if (sorteer == "oplopend")
            {
                return lijst.OrderBy(t => t.FirstName.ToLower());
            }
            else
            {
                return lijst.OrderByDescending(t => t.FirstName.ToLower());
            }
        }

        public IQueryable<Tenant> Zoek(IQueryable<Tenant> lijst, string zoek)
        {
            if (zoek == null)
            {
                return lijst;
            }
            else
            {
                return lijst.Where(t => t.FirstName.ToLower().Contains(zoek.ToLower()));
            }
        }

        public IQueryable<Tenant> Pagineer(IQueryable<Tenant> lijst, int pagina, int aantal)
        {
            if(pagina < 0) pagina = 0;
            return lijst.Skip(pagina * aantal).Take(aantal);
        }

        // GET: Tenant
        public async Task<IActionResult> Index(string sorteer, string zoek, int pagina)
        {
            if (sorteer == null)
            {
                sorteer = "oplopend";
            }
            ViewData["sorteer"] = sorteer;
            ViewData["zoek"] = zoek;
            ViewData["pagina"] = pagina;
            ViewData["heeftVolgende"] = (pagina + 1) * 10 < _context.Tenants.Count();
            ViewData["heeftVorige"] = pagina > 0;
            return View(await Pagineer(Zoek(Sorteer(_context.Tenants, sorteer), zoek), pagina, 10).Include(t => t.Rent).ToListAsync());
        }

        // GET: Tenant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenant/Create
        public IActionResult Create()
        {
            ViewData["Cars"] = _context.Cars.AsAsyncEnumerable<Car>();
            return View();
        }

        // POST: Tenant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Tenant tenant, int rent)
        {

            if (ModelState.IsValid)
            {
                tenant.Rent = _context.Cars.Find(rent);
                _context.Add(tenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenant);
        }

        // GET: Tenant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return View(tenant);
        }

        // POST: Tenant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.Id))
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
            return View(tenant);
        }

        // GET: Tenant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenantExists(int id)
        {
            return _context.Tenants.Any(e => e.Id == id);
        }
    }
}
