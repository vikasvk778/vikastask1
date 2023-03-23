using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly DataContext context;

        public UserController(DataContext Context)
        {
            context = Context;
        }


       // GetAttribute ALL USERS
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {

            return Ok(await context.users.ToListAsync());
        }
        // GET USER BY USERID
        [HttpGet("{user_id}")]
        public async Task<ActionResult<List<User>>> Get(string user_id)
        {
            var User = await context.users.FindAsync(user_id);
            if (User == null)
                return BadRequest("user not found");
            return Ok(User);
        }

        //CREATE NEW USER
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();

            return Ok(await context.users.ToListAsync());
        }
        //update existing user
        [HttpPut]
        public async Task<ActionResult<List<User>>> updateUser(User request)
        {
            var dbUser = await context.users.FindAsync(request.User_ID);
            if (User == null)
                return BadRequest("user not found");
            dbUser.Email = request.Email;
            dbUser.Location = request.Location;
            dbUser.Last_Name = request.Last_Name;
            dbUser.First_Name = request.First_Name;

            await context.SaveChangesAsync();

            return Ok(await context.users.ToListAsync());

        }

        //delete by userid
        [HttpDelete("{user_id}")]
        public async Task<ActionResult<List<User>>> Delete(string user_id)
        {
            var dbUser = await context.users.FindAsync(user_id);
            if (dbUser == null)
                return BadRequest("user not found");

            context.users.Remove(dbUser);
            await context.SaveChangesAsync();
            return Ok(await context.users.ToListAsync());
        }
    }
}

