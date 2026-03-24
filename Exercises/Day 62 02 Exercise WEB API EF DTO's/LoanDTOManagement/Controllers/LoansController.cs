using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanDTOManagement.Data;
using LoanDTOManagement.Models;
using LoanDTOManagement.DTOs;
using AutoMapper;

namespace LoanDTOManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanDTOManagementContext _context;
        private readonly IMapper _mapper;

        public LoansController(LoanDTOManagementContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // ✅ GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDTO>>> GetLoan()
        {
            var loans = await _context.Loan.ToListAsync();

            var result = _mapper.Map<List<LoanReadDTO>>(loans);

            return result;
        }

        // ✅ GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanReadDTO>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            var result = _mapper.Map<LoanReadDTO>(loan);

            return result;
        }

        // ✅ POST: api/Loans
        [HttpPost]
        public async Task<ActionResult<LoanReadDTO>> PostLoan(LoanCreateDTO Loandto)
        {

            var loan = _mapper.Map<Loan>(Loandto);
            //var loan = new Loan
            //{
            //    BorrowerName = dto.BorrowerName,
            //    Amount = dto.Amount,
            //    LoanTermMonths = dto.LoanTermMonths,
            //    IsApproved = dto.IsApproved
            //};

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<LoanReadDTO>(loan);


            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, result);
        }

        // ✅ PUT: api/Loans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, LoanUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            // 🔥 AutoMapper mapping (replaces manual mapping)
            _mapper.Map(dto, loan);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}