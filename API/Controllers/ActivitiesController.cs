using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var temp = await _context.Activities.ToListAsync();
            return Ok(temp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var temp = await _context.Activities.FirstOrDefaultAsync(p=>p.Id == id);
            return Ok(temp);
        }
    }
}