using AutoMapper;
using Meal.Shared.DTOs;
using MealOrder.Server.Services.Abstractions;
using MealOrder.ServerData.Context;
using MealOrder.ServerData.Model;
using Microsoft.EntityFrameworkCore;

namespace MealOrder.Server.Services.Concrete
{
    public class SupplierService:ISupplierService
    {
        private readonly IMapper mapper;
        private readonly MealContext context;

        public SupplierService(IMapper mapper, MealContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task CreateAsync(SupplierDTO SupplierDTO)
        {
            await context.Suppliers.AddAsync(mapper.Map<Supplier>(SupplierDTO));
            await context.SaveChangesAsync();
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
            if (supplier is null)
                throw new Exception("Melumat tapilmadi");

            context.Suppliers.Remove(supplier);
            return await context.SaveChangesAsync() > 0;
        }



        public async Task<SupplierDTO> GetByIdAsync(int id)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id && x.IsAktiv);
            if (supplier is null)
                throw new Exception("Melumat tapilmadi");

            return mapper.Map<SupplierDTO>(supplier);
        }



        public List<SupplierDTO> GetAllList()
        {
            var supplier = context.Suppliers.Where(x => x.IsAktiv).ToList();
            if (supplier is null)
            {
                throw new Exception("Melumat tapilmadi");
                
            }
             

            return mapper.Map<List<SupplierDTO>>(supplier);
        }

        public async Task UpdateAsync(SupplierDTO SupplierDTO)
        {
            context.Suppliers.Update(mapper.Map<Supplier>(SupplierDTO));
            await context.SaveChangesAsync();
        }


    }
}
