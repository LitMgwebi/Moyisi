using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            IEnumerable<User> users = await _user.GetAll();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            User user = await _user.GetUserById(id);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _user.Create(user);
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _user.Edit(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _user.GetUserById(id);
            await _user.Delete(user);
            return Ok();
        }
    }
}
