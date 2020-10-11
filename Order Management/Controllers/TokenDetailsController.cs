using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;

namespace Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenDetailsController : ControllerBase
    {
        private readonly DeliveryTokenDB _context;

        public TokenDetailsController(DeliveryTokenDB context)
        {
            _context = context;
        }

        // GET: api/TokenDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TokenDetail>>> GetOrderDetails()
        {
            return await _context.TokenDetails.ToListAsync();
        }

        // GET: api/TokenDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TokenDetail>> GetOrderDetail(string id)
        {
            var orderDetail = await _context.TokenDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/TokenDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, TokenDetail tokenDetail)
        {

            TokenDetail.id = id;

            _context.Entry(tokenDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TokenDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TokenDetail>> PostOrderDetail(TokenDetail tokenDetail)
        {
            _context.TokenDetails.Add(tokenDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderDetailExists(tokenDetail.Token_Number))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderDetail", new { id = tokenDetail.Token_Number }, tokenDetail);
        }

        // DELETE: api/TokenDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TokenDetail>> DeleteOrderDetail(string id)
        {
            var orderDetail = await _context.TokenDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.TokenDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return orderDetail;
        }

        private bool OrderDetailExists(int id)
        {
            return _context.TokenDetails.Any(e => e.Token_Number == id);
        }
    }
}
