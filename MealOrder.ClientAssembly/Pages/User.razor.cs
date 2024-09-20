using Meal.Shared.DTOs;
using Meal.Shared.ResponseModel;
using MealOrder.ClientAssembly.AppClasses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace MealOrder.ClientAssembly.Pages;

public class UserBase:ComponentBase
{
    [Inject]
    public NavigationManager navigationManager { get; set; }
    [Inject]
    public HttpClient client { get; set; }
    public string Message { get; set; }

    protected ServiceResponse<List<UserDTO>> users=new ServiceResponse<List<UserDTO>>();
 
    protected override async Task OnInitializedAsync()
    {
        try
        {
            users = await client.GetServiceAsync<List<UserDTO>>("http://localhost:5005/api/User/GetAll");
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
    }

    protected void Insert()
    {
        navigationManager.NavigateTo("/insert");
    }
    protected void Edit(int UserId)
    {
        navigationManager.NavigateTo($"/useredit/{UserId}");
    }
}
