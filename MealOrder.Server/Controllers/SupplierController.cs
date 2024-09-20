using AutoMapper;
using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.Server.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealSupplier.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService SupplierService;

        public SupplierController(ISupplierService SupplierService)
        {
            this.SupplierService = SupplierService;
        }

        [HttpGet]
        public ServiceResponse<List<SupplierDTO>> GetAll()
        {
            return new ServiceResponse<List<SupplierDTO>>()
            {
                Value = SupplierService.GetAllList()
            };
        }

        [HttpGet]
        public async Task<ServiceResponse<SupplierDTO>> GetById([FromQuery] int id)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await SupplierService.GetByIdAsync(id)
            };
        }
        [HttpPut]
        public async Task Update([FromBody] SupplierDTO request)
        {
            await SupplierService.UpdateAsync(request);
        }

        [HttpPost]
        public async Task Create([FromBody] SupplierDTO request)
        {
            await SupplierService.CreateAsync(request);
        }


        [HttpDelete]
        public async Task Remove([FromQuery] int id)
        {
            await SupplierService.DeleteAsync(id);
        }
    }
}
