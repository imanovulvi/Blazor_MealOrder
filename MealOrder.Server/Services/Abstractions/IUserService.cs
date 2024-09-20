using Meal.Shared.DTOs;

namespace MealOrder.Server.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserLoginResponseDTO> LoginAsync(UserLoginRequestDTO requestDTO);
        List<UserDTO> GetAllList();
        Task<UserDTO> GetByIdAsync(int id);
        Task CreateAsync(UserDTO userDTO);
        Task UpdateAsync(UserDTO userDTO);
        Task<bool> DeleteAsync(int id);
    }
}
