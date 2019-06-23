using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiInClientwithJWT.DAL;
using apiInClientwithJWT.Models;

namespace apiInClientwithJWT.Controllers
{
    [Route("api/example")]
    [ApiController]
    public class ApisController : ControllerBase
    {
        private readonly ApiContext _context;

        public ApisController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Apis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Api>>> GetApi()
        {
            return await _context.Api.ToListAsync();
        }

        // GET: api/Apis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Api>> GetApi(int id)
        {
            var api = await _context.Api.FindAsync(id);

            if (api == null)
            {
                return NotFound();
            }

            return api;
        }

        // PUT: api/Apis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApi(int id, Api api)
        {
            if (id != api.Id)
            {
                return BadRequest();
            }

            _context.Entry(api).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiExists(id))
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

        // POST: api/Apis
        [HttpPost]
        public async Task<ActionResult<Api>> PostApi(Api api)
        {
            _context.Api.Add(api);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApi", new { id = api.Id }, api);
        }

        // DELETE: api/Apis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Api>> DeleteApi(int id)
        {
            var api = await _context.Api.FindAsync(id);
            if (api == null)
            {
                return NotFound();
            }

            _context.Api.Remove(api);
            await _context.SaveChangesAsync();

            return api;
        }

        private bool ApiExists(int id)
        {
            return _context.Api.Any(e => e.Id == id);
        }
    }
}
