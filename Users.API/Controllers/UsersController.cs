using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.API.Data;
using Users.API.Data.Repositories;
using Users.API.Models;

namespace Users.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUserRepository repository;

        public UsersController(ILogger<UsersController> logger ,IUserRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        // GET /Users
        [HttpGet]
        public IActionResult GetAll()
        {   
            var users = repository.GetAll();
            
            logger.LogInformation($"Endpoint -> api/users -> GET {DateTime.Now}");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = repository.GetById(id);

            if (user == null)
                return NotFound();

            logger.LogInformation($"Endpoint -> api/users/id -> GET(id) {user.Id} {DateTime.Now}");

            return Ok(user);
        }

        // POST /Users
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var createUser = new User(user.FirstName, user.Surname, user.Age);

            repository.Add(createUser);

            logger.LogInformation($"Endpoint -> api/users -> POST -> User(id) {createUser.Id} {createUser.CreationDate}");

            return CreatedAtAction(nameof(GetById), new { id = createUser.Id }, createUser);
        }

        // PUT /Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id,[FromBody] User user)
        {

            var updateUser = repository.GetById(id);

            if (updateUser == null)
                return NotFound();

            updateUser.Update(user.FirstName, user.Surname, user.Age);

            repository.Update(updateUser);

            logger.LogInformation($"Endpoint -> api/users/id -> PUT(id) {updateUser.Id} {DateTime.Now}");
            
            return NoContent();
        }

        // DELETE /Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = repository.GetById(id);

            if (user == null)
                return NotFound();

            repository.Delete(user);

            logger.LogInformation($"Endpoint -> api/users/id -> DELETE(id) {user.Id} {DateTime.Now}");

            return NoContent();
        }

    }
}
