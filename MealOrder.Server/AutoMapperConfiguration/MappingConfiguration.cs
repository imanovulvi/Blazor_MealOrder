using AutoMapper;
using Meal.Shared.DTOs;
using MealOrder.ServerData.Model;

namespace MealOrder.Server.AutoMapperConfiguration
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}
