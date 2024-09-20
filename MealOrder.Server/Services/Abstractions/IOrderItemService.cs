using Meal.Shared.DTOs;

namespace MealOrder.Server.Services.Abstractions
{
    public interface IOrderItemService
    {
        List<OrderItemDTO> GetAllList();
        Task<OrderItemDTO> GetByIdAsync(int id);
        Task CreateAsync(OrderItemDTO OrderItemDTO);
        Task UpdateAsync(OrderItemDTO OrderItemDTO);
        Task<bool> DeleteAsync(int id);
    }
}
