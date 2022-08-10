using API.Data.DTOs;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region  Initializations of controller
        private readonly IService<User> userService;

        public UserController(IService<User> userService)
        {
            this.userService = userService;
        }
        #endregion
        #region  Methods
        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            return Ok(userService.GetAll().Select(user => new UserDTO(user)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await userService.GetAsync(id);
            return Ok(new UserDTO(user));
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDTO user)
        {
            try 
            {
                await userService.CreateAsync(new User(user));
                return Ok();
            }
            catch(Exception ex)
            {
                return UnprocessableEntity(ex);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserDTO user)
        {
            try
            {
                await userService.UpdateAsync(new User(user), id);
                return Ok();
            }
            catch(Exception ex)
            {
                return UnprocessableEntity(ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await userService.DeleteAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
        #endregion
    }
}