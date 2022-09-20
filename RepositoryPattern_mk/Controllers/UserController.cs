using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RepositoryPattern_mk.Core.IConfiguration;
using RepositoryPattern_mk.Data;
using RepositoryPattern_mk.Models;
using System.Threading.Tasks;

namespace RepositoryPattern_mk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork)
        {
           
            _logger = logger;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.CompleteAsync();
                return CreatedAtAction("GetItem", new { user.Id }, user);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users =  await _unitOfWork.Users.All();
            return Ok(users);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.Users.Update(user);
                await _unitOfWork.CompleteAsync();
                return Ok(user);
            }        

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                await _unitOfWork.Users.Delete(id);
                await _unitOfWork.CompleteAsync();
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
