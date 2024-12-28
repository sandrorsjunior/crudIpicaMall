using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudIpcaMall.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersInterface _userService;
        public UsersController(UsersInterface service)
        {
            this._userService = service;
        }

        [HttpGet("allUsers")]
        public async Task<ActionResult<ResponseModel<List<UsersModel>>>> ListAllUsers()
        {
            var users = await this._userService.ListarUsers();
            return Ok(users);
        }

        [HttpPost("creatUser")]
        public async Task<ActionResult<ResponseModel<UsersModel>>> CriarAutor(UsersCreateDTO userDto)
        {
            var user = await this._userService.CreateNewUser(userDto);
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseModel<UsersModel>>> Longin(LoginDTO loginDTO)
        {
            var login = await this._userService.Login(loginDTO);
            return Ok(login);
        }

    }
}