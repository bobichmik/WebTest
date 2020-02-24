using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DataController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModel>>> GetDataItems()
        {
            return await _context.DataItems.ToListAsync();
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModel>> GetDataModel(int id)
        {
            var dataModel = await _context.DataItems.FindAsync(id);

            if (dataModel == null)
            {
                return NotFound();
            }

            return dataModel;
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataModel(int id, DataModel dataModel)
        {
            if (id != dataModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataModelExists(id))
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

        // POST: api/Data
        [HttpPost]
        public async Task<ActionResult<DataModel>> PostDataModel(DataModel dataModel)
        {
            _context.DataItems.Add(dataModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDataModel), new { id = dataModel.Id }, dataModel);
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModel>> DeleteDataModel(int id)
        {
            var dataModel = await _context.DataItems.FindAsync(id);
            if (dataModel == null)
            {
                return NotFound();
            }

            _context.DataItems.Remove(dataModel);
            await _context.SaveChangesAsync();

            return dataModel;
        }

        private bool DataModelExists(int id)
        {
            return _context.DataItems.Any(e => e.Id == id);
        }
    }
}
