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
    public class AccountsController : Controller
    {
        private readonly Week_10_AssessmentContext _context;

        public AccountsController(Week_10_AssessmentContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            if (!_context.Accounts.Any())
            {
                var defaultAccounts = new List<Account>
        {
            new Account
            {
                AccountNumber = "ACC1001",
                AccountName = "Savings Account",
                Balance = 50000
            },

            new Account
            {
                AccountNumber = "ACC1002",
                AccountName = "Current Account",
                Balance = 30000
            }
        };

                _context.Accounts.AddRange(defaultAccounts);
                await _context.SaveChangesAsync();
            }
            var accounts = _context.Accounts
        .Include(a => a.Transactions)
        .ToList();

            return View(accounts);
        }

        public IActionResult Details(int id)
        {
            var account = _context.Accounts
                .FirstOrDefault(a => a.Id == id);

            return View(account);
        }



        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();

                // Toast Message
                TempData["Success"] = "Account created successfully!";

                return RedirectToAction("Index");
            }

            return View(account);
        }
        // EDIT
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.Find(id);
            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }




        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = _context.Accounts
        .Include(a => a.Transactions)
        .FirstOrDefault(a => a.Id == id);

            if (account != null)
            {
                _context.Transactions.RemoveRange(account.Transactions);
                _context.Accounts.Remove(account);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
