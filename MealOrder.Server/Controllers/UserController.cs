using Azure;
using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using Meal.Shared.Tools;
using MealOrder.Server.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ServiceResponse<List<UserDTO>> GetAll()
        {
            return new ServiceResponse<List<UserDTO>>()
            {
                Value = userService.GetAllList()
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<UserDTO>> GetById([FromQuery]int id)
        {
            return new ServiceResponse<UserDTO>()
            {
                Value =await  userService.GetByIdAsync(id)
            };
        }
        [HttpPut]
        public async Task Update([FromBody]UserDTO request)
        {
            await userService.UpdateAsync(request);
        }

        [HttpPost]
        public async Task Create([FromBody] UserDTO request)
        {
            EncriptionPassword encription = new EncriptionPassword(); 
             request.Password= encription.Password(request.Password);
            await userService.CreateAsync(request);
        }


        [HttpDelete]
        public async Task Remove([FromQuery]int id)
        {
           await userService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<UserLoginResponseDTO> Login([FromBody]UserLoginRequestDTO login)
        {
           return await userService.LoginAsync(login);
        }
    }
}
