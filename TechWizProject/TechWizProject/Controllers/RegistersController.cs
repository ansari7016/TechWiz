using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechWizProject.Data;
using TechWizProject.Models;

namespace TechWizProject.Controllers
{
    public class RegistersController : Controller
    {
        private readonly TechWizProjectContext _context;

        public RegistersController(TechWizProjectContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            var techWizProjectContext = _context.Registers.Include(r => r.UserType);
            return View(await techWizProjectContext.ToListAsync());
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .Include(r => r.UserType)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/CreateTeacher
        public IActionResult CreateTeacher()
        {
            //ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename");
            return View();
        }

        // GET: Registers/CreateParent
        public IActionResult CreateParent()
        {
            //ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename");
            return View();
        }
        public IActionResult Create()
        {
            //ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename");
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Register register)
        {
            try
            {
                if (register.Address == null)
                {
                    register.Address = "NA";
                }
               if (register.Age == null)
                {
                    register.Age = 0;
                }
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.m = "Error";
            }
        
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename", register.UserTypeId);
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename", register.UserTypeId);
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterId,Name,Email,Password,ConfirmPassword,Age,Address,UserTypeId")] Register register)
        {
            if (id != register.RegisterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.RegisterId))
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
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "UserTypeId", "Typename", register.UserTypeId);
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .Include(r => r.UserType)
                .FirstOrDefaultAsync(m => m.RegisterId == id);
            if (register == null)   
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'TechWizProjectContext.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return (_context.Registers?.Any(e => e.RegisterId == id)).GetValueOrDefault();
        }
    }
}
