using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.ClientServer.AppClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MealOrder.ClientServer.Pages
{
    public class UserBase : ComponentBase
    {
        protected ServiceResponse<List<UserDTO>> users = new ServiceResponse<List<UserDTO>>();
        public String Message { get; set; }

        [Inject]
        public HttpClient client { get; set; }

        [Inject]
        public IConfiguration configuration { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IJSRuntime jSRuntime { get; set; }
        

        protected async override Task OnInitializedAsync()
        {
            try
            {
                var result = await client.GetServiceAsync<List<UserDTO>>(configuration["api"]);

                if (result.Success)
                {
                    users = result;
                }
                else
                {
                    Message = "melumat tapilmadi";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }


        }

        protected void EditOrInsert(string url)
        {
            navigationManager.NavigateTo(url);
        }

        protected async Task Delete(int id)
        {
           var yesno=await  jSRuntime.InvokeAsync<bool>("confirm", "Do you deleted?");
            if (yesno)
            {
                var result = await client.DeleteServiceAsync($"http://localhost:5005/api/User/Remove?id={id}");
                if (result)
                    await OnInitializedAsync();

                else
                    Message = "Xeta bas verdi";
            }
         
        }
    }
}
