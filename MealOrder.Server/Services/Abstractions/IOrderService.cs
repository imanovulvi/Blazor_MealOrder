using Meal.Shared.DTOs;

namespace MealOrder.Server.Services.Abstractions
{
    public interface IOrderService
    {
        List<OrderDTO> GetAllList();
        Task<OrderDTO> GetByIdAsync(int id);
        Task CreateAsync(OrderDTO OrderDTO);
        Task UpdateAsync(OrderDTO OrderDTO);
        Task<bool> DeleteAsync(int id);
        Task<List<OrderDTO>> GetByFilterAsync(OrderFilter filter);
    }
}
