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
        public IActionResult CreateUser([FromBody] CreateUserModel createUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new User(createUser.firstName, createUser.surname, createUser.age);

            repository.Add(user);

            logger.LogInformation($"Endpoint -> api/users -> POST -> User(id) {user.Id} {user.CreationDate}");

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT /Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id,[FromBody] UpdateUserModel updateUser)
        {

            var user = repository.GetById(id);

            if (user == null)
                return NotFound();

            user.Update(updateUser.name, updateUser.surname, updateUser.age);

            repository.Update(user);

            logger.LogInformation($"Endpoint -> api/users/id -> PUT(id) {user.Id} {DateTime.Now}");
            
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
