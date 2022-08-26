using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartApi.Data;
using CartApi.Models;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartApiContext _context;

        public CartsController(CartApiContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> GetCart()
        {
            return Ok(await _context.Carts.ToListAsync());
        }
        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
          if (_context.Carts == null)
          {
              return NotFound();
          }
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<IActionResult> PutCart(Cart cart)
        {
            var dbCart = await _context.Carts.FindAsync(cart.Id);
            if (dbCart == null)
                return BadRequest("Hero not found.");

            dbCart.ProductId = cart.ProductId;
            dbCart.ProductName = cart.ProductName;
            dbCart.Qty = cart.Qty;
            dbCart.Price = cart.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.Carts.ToListAsync());
        }
            // POST: api/Carts
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return Ok(await _context.Carts.ToListAsync());
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var dbCart = await _context.Carts.FindAsync(id);
            if (dbCart == null)
                return BadRequest("Hero not found.");

            _context.Carts.Remove(dbCart);
            await _context.SaveChangesAsync();

            return Ok(await _context.Carts.ToListAsync());
        }

        private bool CartExists(int id)
        {
            return (_context.Carts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
