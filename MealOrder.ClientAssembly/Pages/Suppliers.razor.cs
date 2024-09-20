using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.ClientAssembly.AppClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MealOrder.ClientAssembly.Pages
{
    public partial class Suppliers : ComponentBase
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public HttpClient client { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public string Message { get; set; }

        public ServiceResponse<List<SupplierDTO>> supplier = new ServiceResponse<List<SupplierDTO>>();
        protected override async Task OnInitializedAsync()
        {
            supplier = await client.GetServiceAsync<List<SupplierDTO>>("http://localhost:5005/api/Supplier/GetAll");
        }

        public void EdinOrInsert(int id)
        {
            navigationManager.NavigateTo($"/SupliersEditOrInsert/{id}");
        }

        public async Task Delete(int id)
        {
            var ques = await JS.InvokeAsync<bool>("confirm", "Do you deleted?");
            if (ques)
            {
                var rsult = await client.DeleteServiceAsync($"http://localhost:5005/api/Supplier/Remove?id={id}");
                if (!rsult)
                    Message = "Xeta bas verdi";
            }
            await OnInitializedAsync();

        }
    }
}
