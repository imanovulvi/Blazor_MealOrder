using Meal.Shared.ResponseModel;
using Newtonsoft.Json;
using System.Text;

namespace MealOrder.ClientAssembly.AppClasses
{
    public static class HttpClientExtension
    {
        public static async Task<ServiceResponse<T>> GetServiceAsync<T>(this HttpClient client,String url) where T : class
        {
            var result=await client.GetAsync(url);
            var httpRes=JsonConvert.DeserializeObject<ServiceResponse<T>>(await result.Content.ReadAsStringAsync());
        
            if (!httpRes.Success)
                throw new Exception("melumat tapilmadi");

                return httpRes;
          
        }
        public static async Task<(bool, TResult)> PostServiceAsync<T, TResult>(this HttpClient client, string url, T model)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var resul = await client.PostAsync(url, stringContent);

            return (resul.IsSuccessStatusCode, JsonConvert.DeserializeObject<TResult>(await resul.Content.ReadAsStringAsync()));


        }

        public static async Task<bool> PostServiceAsync<T>(this HttpClient client,string url,T model)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var resul = await client.PostAsync(url, stringContent);

            return resul.IsSuccessStatusCode;
          
  
        }
        public static async Task<bool> PutServiceAsync<T>(this HttpClient client, string url, T model)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var resul = await client.PutAsync(url, stringContent);

            return resul.IsSuccessStatusCode;


        }
        public static async Task<bool> DeleteServiceAsync(this HttpClient client, string url)
        {

            var resul = await client.DeleteAsync(url);

            return resul.IsSuccessStatusCode;


        }


    }
}
