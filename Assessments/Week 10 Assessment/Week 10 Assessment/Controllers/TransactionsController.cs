using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week_10_Assessment.Data;
using Week_10_Assessment.Models;

namespace Week_10_Assessment.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly Week_10_AssessmentContext _context;

        public TransactionsController(Week_10_AssessmentContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            if (!_context.Transactions.Any())
            {
                var defaultTransactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Description = "Salary",
                        Amount = 20000,
                        Category = "Income",
                        Date = DateTime.Now,
                        AccountId = 1
                    },

                    new Transaction
                    {
                        Description = "Groceries",
                        Amount = 500,
                        Category = "Expense",
                        Date = DateTime.Now,
                        AccountId = 1
                    },

                    new Transaction
                    {
                        Description = "Office Rent",
                        Amount = 8000,
                        Category = "Expense",
                        Date = DateTime.Now,
                        AccountId = 2
                    }
                };

                _context.Transactions.AddRange(defaultTransactions);
                await _context.SaveChangesAsync();
            }

            var transactions = _context.Transactions
        .Include(t => t.Account)
        .ToList();

            return View(transactions);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewBag.AccountId = new SelectList(_context.Accounts, "Id", "AccountName");
            return View(); ;
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);

            ViewBag.AccountId = new SelectList(_context.Accounts, "Id", "AccountName", transaction.AccountId);

            return View(transaction);

        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id", transaction.AccountId);
            return View(transaction);
            _context.Update(transaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Account");
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Account");
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
