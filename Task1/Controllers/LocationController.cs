using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly DataContext context;

        public LocationController(DataContext Context)
        {
            context = Context;
        }


        // GetAttribute ALL LOCATIONS
        [HttpGet]
        public async Task<ActionResult<List<Location>>> Get()
        {

            return Ok(await context.locations.ToListAsync());
        }
        // GET locations BY location name
        [HttpGet("{location_name}")]
        public async Task<ActionResult<List<Location>>> Get(string location_name)
        {
            var Location = await context.locations.FindAsync(location_name);
            if (Location == null)
                return BadRequest("location not found");
            return Ok(Location);
        }
        //CREATE NEW LOCATION
        [HttpPost]
        public async Task<ActionResult<List<Location>>> AddLocation(Location location)
        {
            context.locations.Add(location);
            await context.SaveChangesAsync();

            return Ok(await context.locations.ToListAsync());
        }
        //delete by location name
        [HttpDelete("{location_name}")]
        public async Task<ActionResult<List<Location>>> Delete(string location_name)
        {
            var dbLocation = await context.locations.FindAsync(location_name);
            if (dbLocation == null)
                return BadRequest("user not found");

            context.locations.Remove(dbLocation);
            await context.SaveChangesAsync();
            return Ok(await context.locations.ToListAsync());
        }
    }
}
