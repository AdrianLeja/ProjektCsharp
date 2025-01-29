using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektC.Data;
using ProjektC.Models;

namespace ProjektC.Controllers
{
    public class AdopcjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopcjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopcjas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adopcja
                .Include(a => a.IdPracownikaNavigation)
                .Include(a => a.IdUzytkownikaNavigation)
                .Include(a => a.IdZwierzeciaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adopcjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var adopcja = await _context.Adopcja
                .Include(a => a.IdPracownikaNavigation)
                .Include(a => a.IdUzytkownikaNavigation)
                .Include(a => a.IdZwierzeciaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdopcji == id);

            if (adopcja == null) return NotFound();

            return View(adopcja);
        }

        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Create
        public IActionResult Create()
        {
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika");
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia");
            return View();
        }

        // POST: Adopcjas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdAdopcji,IdZwierzecia,IdUzytkownika,IdPracownika,StatusAdopcji,DataRozpoczeciaAdopcji,DataZakonczeniaAdopcji")] Adopcja adopcja)
        {
            if (ModelState.IsValid)
            {
                // Dla tworzenia można nadal użyć zwykłego EF
                _context.Add(adopcja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);
            return View(adopcja);
        }

        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var adopcja = await _context.Adopcja.FindAsync(id);
            if (adopcja == null) return NotFound();

            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);

            return View(adopcja);
        }

        // POST: Adopcjas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("IdAdopcji,IdZwierzecia,IdUzytkownika,IdPracownika,StatusAdopcji,DataRozpoczeciaAdopcji,DataZakonczeniaAdopcji")] Adopcja adopcja)
        {
            if (id != adopcja.IdAdopcji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // --------------- ZAMIANA standardowego UPDATE na procedurę ---------------
                    // Wywołujemy w bazie spUpdateAdopcja (musi istnieć).
                    // Parametry: (id_adopcji, data_rozp..., data_zakonczenia..., id_prac, id_uzytk, id_zwierz)
                    await _context.Database.ExecuteSqlRawAsync(
                        @"EXEC spUpdateAdopcja 
                           @p0, 
                           @p1, 
                           @p2, 
                           @p3, 
                           @p4, 
                           @p5",
                        adopcja.IdAdopcji,
                        adopcja.DataRozpoczeciaAdopcji,
                        adopcja.DataZakonczeniaAdopcji,  // może być null
                        adopcja.IdPracownika,
                        adopcja.IdUzytkownika,
                        adopcja.IdZwierzecia
                    );

                    // Nie wywołujemy już _context.Update(adopcja) i SaveChanges() dla Adopcji,
                    // bo to spowodowałoby 'UPDATE ... OUTPUT ...' i błąd z triggerem.
                    // Teraz cała logika update + wpis do logu jest w spUpdateAdopcja.

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcjaExists(adopcja.IdAdopcji))
                        return NotFound();
                    else
                        throw;
                }
            }

            // Walidacja się nie powiodła -> wracamy do widoku
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);
            return View(adopcja);
        }

        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var adopcja = await _context.Adopcja
                .Include(a => a.IdPracownikaNavigation)
                .Include(a => a.IdUzytkownikaNavigation)
                .Include(a => a.IdZwierzeciaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdopcji == id);
            if (adopcja == null) return NotFound();

            return View(adopcja);
        }

        // POST: Adopcjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcja = await _context.Adopcja.FindAsync(id);
            if (adopcja != null)
            {
                _context.Adopcja.Remove(adopcja);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcjaExists(int id)
        {
            return _context.Adopcja.Any(e => e.IdAdopcji == id);
        }
    }
}
