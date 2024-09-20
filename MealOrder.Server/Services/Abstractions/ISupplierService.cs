using Meal.Shared.DTOs;

namespace MealOrder.Server.Services.Abstractions
{
    public interface ISupplierService
    {
        List<SupplierDTO> GetAllList();
        Task<SupplierDTO> GetByIdAsync(int id);
        Task CreateAsync(SupplierDTO SupplierDTO);
        Task UpdateAsync(SupplierDTO SupplierDTO);
        Task<bool> DeleteAsync(int id);
    }
}
