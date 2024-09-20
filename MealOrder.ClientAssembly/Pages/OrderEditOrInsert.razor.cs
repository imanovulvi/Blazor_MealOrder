using Meal.Shared.DTOs;
using MealOrder.ClientAssembly.AppClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MealOrder.ClientAssembly.Pages
{
    public partial class OrderEditOrInsert:ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider authenticationState { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        public HttpClient client { get; set; }
        [Parameter]
        public int Id { get; set; }
        OrderDTO order = new OrderDTO();
        List<SupplierDTO> supplier = new List<SupplierDTO>();
        public int UserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (Id > 0)
            {
                order = (await client.GetServiceAsync<OrderDTO>($"http://localhost:5005/api/Order/GetById?id={Id}")).Value;
               
            }
            supplier= (await client.GetServiceAsync<List<SupplierDTO>>("http://localhost:5005/api/Supplier/GetAll")).Value;

            UserId = Convert.ToInt32((await (authenticationState as CuntomAuthenticationState).GetAuthenticationStateAsync()).User.Claims.ToList()[0].Value);

        }

        public async Task InserOrEdit() 
        {

            if (Id==0)
            {
                var result=await client.PostServiceAsync("http://localhost:5005/api/Order/Create", order);
                if (!result)
                    Message = "xeta bas verdi";
                else
                    navigationManager.NavigateTo("/orders");
            }
            else
            {
                if (UserId == order.UserId)
                {
                    var result = await client.PutServiceAsync("http://localhost:5005/api/Order/Update", order);
                    if (!result)
                        Message = "xeta bas verdi";
                    else
                        navigationManager.NavigateTo("/orders");
                }

            }
        }

    }
}
