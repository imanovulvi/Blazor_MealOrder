using AutoMapper;
using Meal.Shared.DTOs;
using MealOrder.Server.Services.Abstractions;
using MealOrder.ServerData.Context;
using MealOrder.ServerData.Model;
using Microsoft.EntityFrameworkCore;

namespace MealOrder.Server.Services.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly IMapper mapper;
        private readonly MealContext context;

        public OrderService(IMapper mapper, MealContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<OrderDTO>> GetByFilterAsync(OrderFilter filter)
        {
            var query=context.Orders.AsQueryable();

            if (filter.UserId != 0)
                query = query.Where(x=>x.UserId==filter.UserId);
            if (filter.CreateDateMin != DateTime.MinValue)
                query = query.Where(x=>x.CreateDate>=filter.CreateDateMin);
            if (filter.CreateDateMax != DateTime.MinValue)
                query = query.Where(x => x.CreateDate <= filter.CreateDateMax);

            var orders=await query.ToListAsync();
            if (orders is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<List<OrderDTO>>(orders);
        }


        public async Task CreateAsync(OrderDTO orderDTO)
        {
            await context.Orders.AddAsync(mapper.Map<Order>(orderDTO));
            await context.SaveChangesAsync();
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order is null)
                throw new Exception("Melumat tapilmadi");

            context.Orders.Remove(order);
            return await context.SaveChangesAsync() > 0;
        }



        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id && x.IsAktiv);
            if (order is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<OrderDTO>(order);
        }



        public List<OrderDTO> GetAllList()
        {
            var orders = context.Orders.Where(x => x.IsAktiv).ToList();
            if (orders is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task UpdateAsync(OrderDTO OrderDTO)
        {
            context.Orders.Update(mapper.Map<Order>(OrderDTO));
            await context.SaveChangesAsync();
        }


    }
}
