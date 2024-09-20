using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.ClientAssembly.AppClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MealOrder.ClientAssembly.Pages
{
    public partial class Order : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider authenticationState { get; set; }
        [Inject]
        public HttpClient client { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        public string Message { get; set; }
        public OrderFilter orderFilter = new OrderFilter();

        public ServiceResponse<List<OrderDTO>> orders = new ServiceResponse<List<OrderDTO>>();

        public int UserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            orders = await client.GetServiceAsync<List<OrderDTO>>("http://localhost:5005/api/Order/GetAll");
            UserId =Convert.ToInt32((await (authenticationState as CuntomAuthenticationState).GetAuthenticationStateAsync()).User.Claims.ToList()[0].Value);
        }


        public async Task GetOrderFilter()
        {
            orders = (await client.PostServiceAsync
                <OrderFilter, ServiceResponse<List<OrderDTO>>>("http://localhost:5005/api/Order/GetByFilter", orderFilter)).Item2;
        }

        public void EditOrInsert(int id)
        {
            navigationManager.NavigateTo($"/ordereditinsert/{id}");
        }
    }
}
