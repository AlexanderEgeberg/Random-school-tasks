using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabyData;

namespace RestCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyApisController : ControllerBase
    {
        private readonly BabyApiContext _context;
        private static int IDCounter = 6;

        public BabyApisController(BabyApiContext context)
        {
            _context = context;
            var count = context.BabyApis.Count();
            if (count == 0)
            {
                _context.BabyApis.Add(new BabyApi(1, 1, 19, 0));
                _context.BabyApis.Add(new BabyApi(2, 2, 10, 1));
                _context.BabyApis.Add(new BabyApi(3, 2, 12, 0));
                _context.BabyApis.Add(new BabyApi(4, 3, 20, 1));
                _context.BabyApis.Add(new BabyApi(5, 1, 15, 1));


                _context.SaveChangesAsync();
            }
        }

        // GET: api/BabyApis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabyApi>>> GetAll()
        {
            return await _context.BabyApis.ToListAsync();
        }

        // GET: api/BabyApis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BabyApi>> GetBabyApi(int id)
        {
            var babyApi = await _context.BabyApis.FindAsync(id);

            if (babyApi == null)
            {
                return NotFound();
            }

            return babyApi;
        }

        // PUT: api/BabyApis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBabyApi(int id, BabyApi babyApi)
        {
            if (id != babyApi.Id)
            {
                return BadRequest();
            }

            _context.Entry(babyApi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BabyApiExists(id))
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

        // POST: api/BabyApis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BabyApi>> InsertData(BabyApi babyApi)
        {
            babyApi.Id = IDCounter;
            _context.BabyApis.Add(babyApi);
            await _context.SaveChangesAsync();

            IDCounter++;
            return CreatedAtAction("GetBabyApi", new { id = babyApi.Id }, babyApi);
        }

        // DELETE: api/BabyApis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BabyApi>> DeleteBabyApi(int id)
        {
            var babyApi = await _context.BabyApis.FindAsync(id);
            if (babyApi == null)
            {
                return NotFound();
            }

            _context.BabyApis.Remove(babyApi);
            await _context.SaveChangesAsync();

            return babyApi;
        }

        private bool BabyApiExists(int id)
        {
            return _context.BabyApis.Any(e => e.Id == id);
        }
    }
}
