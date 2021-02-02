    using System;
    using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using library;

namespace CovidExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidRecordsController : ControllerBase
    {
        private readonly CovidRecordContext _context;
        private static int IDCounter = 5;

        public CovidRecordsController(CovidRecordContext context)
        {
            _context = context;
            var count = context.CovidRecords.Count();
            if (count == 0)
            {
                _context.CovidRecords.Add(new CovidRecord(1,"Roskilde", 7, 7, 7));
                _context.CovidRecords.Add(new CovidRecord(2, "Roskilde", 7, 7, 7));
                _context.CovidRecords.Add(new CovidRecord(3, "Roskilde", 7, 7, 7));
                _context.CovidRecords.Add(new CovidRecord(4, "Roskilde", 7, 7, 7));
                _context.SaveChangesAsync();
            }
        }


        // GET: api/CovidRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidRecord>>> GetCovidRecords()
        {
            return await _context.CovidRecords.ToListAsync();
        }

        // GET: api/CovidRecords/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("id/{id}")]
        public async Task<ActionResult<CovidRecord>> GetCovidRecord(int id)
        {
            var covidRecord = await _context.CovidRecords.FindAsync(id);

            if (covidRecord == null)
            {
                return NotFound();
            }

            return covidRecord;
        }
        [HttpGet("{city}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("city/{city}")]
        public async Task<ActionResult<CovidRecord>> GetCovidRecordCity(string city)
        {
            var covidRecord = _context.CovidRecords.FirstOrDefault(c => c.City == city);

            if (covidRecord == null)
            {
                return NotFound();
            }

            return covidRecord;
        }

        [HttpGet("{household}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("household/{household}")]
        public async Task<ActionResult<IEnumerable<CovidRecord>>> GetCovidRecordHousehold(int household)
        {
            var covidRecord = await _context.CovidRecords.Where(x => x.Household == household).ToListAsync();

            if (covidRecord == null)
            {
                return NotFound();
            }

            return covidRecord;
        }

        // PUT: api/CovidRecords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovidRecord(int id, CovidRecord covidRecord)
        {
            if (id != covidRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(covidRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidRecordExists(id))
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

        // POST: api/CovidRecords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CovidRecord>> PostCovidRecord(CovidRecord covidRecord)
        {
            covidRecord.Id = IDCounter;
            _context.CovidRecords.Add(covidRecord);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCovidRecord", new { id = covidRecord.Id }, covidRecord);
            IDCounter++;
            return CreatedAtAction(nameof(GetCovidRecord), new {id = covidRecord.Id}, covidRecord);
        }

        // DELETE: api/CovidRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CovidRecord>> DeleteCovidRecord(int id)
        {
            var covidRecord = await _context.CovidRecords.FindAsync(id);
            if (covidRecord == null)
            {
                return NotFound();
            }

            _context.CovidRecords.Remove(covidRecord);
            await _context.SaveChangesAsync();

            return covidRecord;
        }

        private bool CovidRecordExists(int id)
        {
            return _context.CovidRecords.Any(e => e.Id == id);
        }
    }
}
