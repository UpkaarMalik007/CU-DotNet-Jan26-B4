using AccountService.Data;
using AccountService.DTOs;
using AccountService.Models;
using AccountService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _service;

        public AccountsController(IAccountServices service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var result = _service.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            var result = _service.Create(dto);
            return Ok(result);
        }


        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            _service.Deposit(dto);
            return Ok("Deposit successful");
        }


        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            _service.Withdraw(dto);
            return Ok("Withdrawal successful");
        }


    }
}
