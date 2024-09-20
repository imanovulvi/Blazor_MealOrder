using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.Server.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }

        [HttpPost]
        public async Task<ServiceResponse<List<OrderDTO>>> GetByFilter(OrderFilter filtr)
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value =await  OrderService.GetByFilterAsync(filtr)
            };
        }

        [HttpGet]
        public ServiceResponse<List<OrderDTO>> GetAll()
        {
            return new ServiceResponse<List<OrderDTO>>()
            {
                Value = OrderService.GetAllList()
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<OrderDTO>> GetById([FromQuery] int id)
        {
            return new ServiceResponse<OrderDTO>()
            {
                Value = await OrderService.GetByIdAsync(id)
            };
        }
        [HttpPut]
        public async Task Update([FromBody] OrderDTO request)
        {
            await OrderService.UpdateAsync(request);
        }

        [HttpPost]
        public async Task Create([FromBody] OrderDTO request)
        {
            await OrderService.CreateAsync(request);
        }


        [HttpDelete]
        public async Task Remove([FromQuery] int id)
        {
            await OrderService.DeleteAsync(id);
        }
    }
}
