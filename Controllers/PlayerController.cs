


using Foreveryone.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 
namespace Foreveryone.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class PlayerController : ControllerBase
   {
      private readonly ApplicationDbContext context;

      public PlayerController(ApplicationDbContext context)
      {
         this.context = context;
      }

      [HttpGet]
      public async Task<ActionResult<List<Player>>> Get()
      {
         return await context.Players.Include(x => x.Warriors).ToListAsync();

      }
      [HttpGet("{id:int}")]
      public async Task<ActionResult<Player>> Get(int id)
      {
         var player = await context.Players.FirstOrDefaultAsync(x => x.Id == id);
         return player != null ? player : NotFound();
      }

      [HttpGet("{nombre}")]
      public async Task<ActionResult<Player>> Get([FromQuery] string nombre)
      {
         var player = await context.Players.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
         return player != null ? player : NotFound();
      }

      [HttpPost]
      public async Task<ActionResult> Post(Player player)
      {
         var playerExist = await context.Players.AnyAsync(x => x.Nombre == player.Nombre)
         {
            return BadRequest("Ya existe un jugador con ese nombre");
         }

         context.Add(player);
         await context.SaveChangesAsync();
         return Ok();
      }
      [HttpPut("{id:int}")]
      public async Task<ActionResult> Put(Player player, int id)
      {
         if (player.Id != id)
         {
            return BadRequest("El id no coincide");
         }
         context.Update(player);
         await context.SaveChangesAsync();
         return Ok();
      }
      [HttpDelete("{id:int}")]
      public async Task<ActionResult> Delete(int id)
      {
         var existe = await context.Players.AnyAsync(x => x.Id == id);
         if (!existe)
         {
            return NotFound();
         }
         context.Remove(new Player() { Id = id });
         await context.SaveChangesAsync();
         return Ok();
      }

   }

}