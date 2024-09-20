using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.Server.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService OrderItemService;

        public OrderItemController(IOrderItemService OrderItemService)
        {
            this.OrderItemService = OrderItemService;
        }

        [HttpGet]
        public ServiceResponse<List<OrderItemDTO>> GetAll()
        {
            return new ServiceResponse<List<OrderItemDTO>>()
            {
                Value = OrderItemService.GetAllList()
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<OrderItemDTO>> GetById([FromQuery] int id)
        {
            return new ServiceResponse<OrderItemDTO>()
            {
                Value = await OrderItemService.GetByIdAsync(id)
            };
        }
        [HttpPut]
        public async Task Update([FromBody] OrderItemDTO request)
        {
            await OrderItemService.UpdateAsync(request);
        }

        [HttpPost]
        public async Task Create([FromBody] OrderItemDTO request)
        {
            await OrderItemService.CreateAsync(request);
        }


        [HttpDelete]
        public async Task Remove([FromQuery] int id)
        {
            await OrderItemService.DeleteAsync(id);
        }
    }
}
