using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inventario_SEBDOM_SAS.Data;
using Control_Inventario_SEBDOM_SAS.Models;

namespace Control_Inventario_SEBDOM_SAS.Controllers
{
    public class BalancesController : Controller
    {
        private readonly Control_Inventario_SEBDOM_SASContext _context;

        public BalancesController(Control_Inventario_SEBDOM_SASContext context)
        {
            _context = context;
        }

        // GET: Balances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Balance.ToListAsync());
        }

        // GET: Balances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // GET: Balances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Balances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreProducto")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                balance.StockActual = 0; // inicializamos stock
                _context.Add(balance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balance);
        }

        // GET: Balances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            return View(balance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, double? Entrada, double? Salida)
        {
            var balance = await _context.Balance.FindAsync(Id);
            if (balance == null)
            {
                return NotFound();
            }

            // Lógica para actualizar el stock actual
            if (Entrada.HasValue)
            {
                balance.StockActual += Entrada.Value;
                balance.Entrada = null; // Limpiar campo temporal
            }

            if (Salida.HasValue)
            {
                balance.StockActual -= Salida.Value;
                balance.Salida = null; // Limpiar campo temporal
            }

            try
            {
                _context.Update(balance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceExists(balance.Id))
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

        // GET: Balances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _context.Balance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var balance = await _context.Balance.FindAsync(id);
            if (balance != null)
            {
                _context.Balance.Remove(balance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(int id)
        {
            return _context.Balance.Any(e => e.Id == id);
        }
    }
}
