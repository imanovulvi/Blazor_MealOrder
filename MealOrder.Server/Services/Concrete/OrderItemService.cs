using AutoMapper;
using Meal.Shared.DTOs;
using MealOrder.Server.Services.Abstractions;
using MealOrder.ServerData.Context;
using MealOrder.ServerData.Model;
using Microsoft.EntityFrameworkCore;

namespace MealOrder.Server.Services.Concrete
{
    public class OrderItemService: IOrderItemService
    {
        private readonly IMapper mapper;
        private readonly MealContext context;

        public OrderItemService(IMapper mapper, MealContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task CreateAsync(OrderItemDTO OrderItemDTO)
        {
            await context.Suppliers.AddAsync(mapper.Map<Supplier>(OrderItemDTO));
            await context.SaveChangesAsync();
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var ordeitem = await context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
            if (ordeitem is null)
                throw new Exception("Melumat tapilmadi");

            context.OrderItems.Remove(ordeitem);
            return await context.SaveChangesAsync() > 0;
        }



        public async Task<OrderItemDTO> GetByIdAsync(int id)
        {
            var ordeitem = await context.OrderItems.FirstOrDefaultAsync(x => x.Id == id && x.IsAktiv);
            if (ordeitem is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<OrderItemDTO>(ordeitem);
        }



        public List<OrderItemDTO> GetAllList()
        {
            var ordeitem = context.OrderItems.Where(x => x.IsAktiv).ToList();
            if (ordeitem is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<List<OrderItemDTO>>(ordeitem);
        }

        public async Task UpdateAsync(OrderItemDTO OrderItemDTO)
        {
            context.OrderItems.Update(mapper.Map<OrderItem>(OrderItemDTO));
            await context.SaveChangesAsync();
        }


    }
}
