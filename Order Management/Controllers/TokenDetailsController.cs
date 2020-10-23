using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using Order_Management.Models.DTO;
using Order_Management.Services.Contracts;

namespace Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly DeliveryTokenDB _context;
        private readonly ITokenDetailService _tokenService;

        public TokensController(DeliveryTokenDB context, ITokenDetailService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // GET: api/Tokens
        [HttpGet]
        public async Task<List<TokenDetailDto>> GetOrderDetails()
        {

            return await _tokenService.GetTokenDetails();
        }

        // GET: api/Tokens/5
        [HttpGet("{id}")]
        public async Task<TokenDetailDto> GetTokenDetail(int id)
        {
            return await _tokenService.GetToken(id);
        }

        // PUT: api/Tokens/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<bool> PutOrderDetail(TokenDetailDto dto)
        {
            return await _tokenService.UpdateToken(dto);
        }

        // POST: api/Tokens
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task PostTokenDetail(TokenDetailDto dto)
        {
            await _tokenService.AddToken(dto);
        }

        // DELETE: api/Tokens/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteTokenDetail(int id)
        {
            return await _tokenService.DeleteToken(id);            
        }

        // DELETE: api/Tokens/5
        [HttpGet("GetStatistics")]
        public async Task<StatisticsDto> GetStatistics()
        {
            return await _tokenService.GetStatistics();
        }


    }
}
