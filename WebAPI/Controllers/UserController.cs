using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccessLayer;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyAppDBContext _context;
        public UserController(MyAppDBContext context)
        {
            _context = context; ;
        }

        /// <summary>
        /// Method <c>Get</c> Gets All Users 
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count == 0)
                {
                    return NotFound("Users not registered");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Method <c>Get</c> Gets Users Based on ID
        /// Paramters <c>id</c> 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound($"User not found with id {id}");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Method <c>Post</c> Insert User into DB
        /// </summary>
        [HttpPost]
        public IActionResult Post(User model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("User Inserted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Method <c>Put</c> Update User if User in Db
        /// </summary>
        [HttpPut]
        public IActionResult Put(User model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("User data is invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"User Id {model.Id} is invalid.");
                }

                var user = _context.Users.Find(model.Id);
                if (user == null)
                {
                    return NotFound($"User not found with id {model.Id}");
                }

                user.Name= model.Name;
                user.Email= model.Email;
                user.IsAdmin= model.IsAdmin;
                user.Password= model.Password;
                _context.SaveChanges();
                return Ok("User details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Method <c>Delete</c> Delete User from DB
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return NotFound($"User not found with id {id}");
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("User details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Method <c>Login</c> Login User API 
        /// </summary>
        [HttpGet("{email}/{password}")]
        public IActionResult Login(string email,string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (user == null)
                {
                    return NotFound("Incorrect Credentials");
                }
                return Ok("Valid User");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
