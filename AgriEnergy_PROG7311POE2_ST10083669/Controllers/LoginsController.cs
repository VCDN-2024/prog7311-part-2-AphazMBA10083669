using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergy_PROG7311POE2_ST10083669.Models;

//Code Rerference:
//C# Code Academy (2018). Create Login Page in Asp.net (MVC 5 & SQL Server).
//[online] YouTube. Available at: https://www.youtube.com/watch?v=-860xZK5mRg&t=458s
//[Accessed 29 May 2024].

namespace AgriEnergy_PROG7311POE2_ST10083669.Controllers
{
    public class LoginsController : Controller
    {
        private readonly AgriEnergyConnectPlatformContext _context;

        public LoginsController(AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var agriEnergyConnectPlatformContext = _context.EmployeeLogins.Include(e => e.Employee);
            return View(await agriEnergyConnectPlatformContext.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogins
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            return View(employeeLogin);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,EmployeeId,Username,PasswordHash")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeLogin.EmployeeId);
            return View(employeeLogin);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogins.FindAsync(id);
            if (employeeLogin == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeLogin.EmployeeId);
            return View(employeeLogin);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoginId,EmployeeId,Username,PasswordHash")] EmployeeLogin employeeLogin)
        {
            if (id != employeeLogin.LoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLoginExists(employeeLogin.LoginId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeLogin.EmployeeId);
            return View(employeeLogin);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogins
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            return View(employeeLogin);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeLogin = await _context.EmployeeLogins.FindAsync(id);
            if (employeeLogin != null)
            {
                _context.EmployeeLogins.Remove(employeeLogin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeLoginExists(int id)
        {
            return _context.EmployeeLogins.Any(e => e.LoginId == id);
        }
    }
}
