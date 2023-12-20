


using Foreveryone.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foreveryone.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class WarriorController : ControllerBase{
        private readonly ApplicationDbContext context;

        public WarriorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Warrior>> Get(int id)
        {
           return await context.Warriors.Include(x => x.Player).FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Warrior warrior)
        {
            var playerExist = await context.Players.AnyAsync(x => x.Id == warrior.PlayerId);
            if(!playerExist)
            {
                return BadRequest("This player doesn't exist");
            }
            context.Add(warrior);
            await context.SaveChangesAsync();
           return Ok();
        }
    }
}