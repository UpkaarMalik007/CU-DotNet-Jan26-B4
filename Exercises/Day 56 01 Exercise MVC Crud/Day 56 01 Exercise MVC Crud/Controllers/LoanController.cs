using Day_56_01_Exercise_MVC_Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_56_01_Exercise_MVC_Crud.Controllers
{

    
    public class LoanController : Controller
    {

        private static List<Loan> loans = new List<Loan>()
        {
            new Loan
            {
                Id = 1,
                BorrowerName = "Rahul Sharma",
                LenderName = "Amit Verma",
                Amount = 15000,
                IsSettled = false
            },
            new Loan
            {
                Id = 2,
                BorrowerName = "Priya Singh",
                LenderName = "Neha Kapoor",
                Amount = 50000,
                IsSettled = true
            },
            new Loan
            {
                Id = 3,
                BorrowerName = "Karan Mehta",
                LenderName = "Rohit Gupta",
                Amount = 120000,
                IsSettled = false
            },
            new Loan
            {
                Id = 4,
                BorrowerName = "Anjali Verma",
                LenderName = "Suresh Patel",
                Amount = 75000,
                IsSettled = true
            }
        };
        // GET: LoanController
        public ActionResult Index()
        {
            return View(loans);
        }

        

        // GET: LoanController/Create
        public ActionResult Add()
        {

            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Loan loan)
        {
            try
            {
                loans.Add(loan);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Loan loan)
        {
            if (id != loan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLoan = loans.FirstOrDefault(l => l.Id == id);

                if (existingLoan == null)
                {
                    return NotFound();
                }

                try
                {
                    
                    existingLoan.Amount = loan.Amount;

                    existingLoan.IsSettled = loan.IsSettled;

                    
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(loan);
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(l => l.Id == id);
            return View(loan);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan loan)
        {
            var exisitingLoan = loans.FirstOrDefault(l => l.Id == id);
            if (exisitingLoan != null)
            {
                loans.Remove(exisitingLoan);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
