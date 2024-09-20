using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace MealOrder.ClientAssembly.AppClasses
{
    public class CuntomAuthenticationState : AuthenticationStateProvider
    {

        private readonly ILocalStorageService localStorageService;

        public CuntomAuthenticationState(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
        
            return new AuthenticationState(await ClaimsPrincipalAsync());
        }
         
        public async Task<ClaimsPrincipal> ClaimsPrincipalAsync()
        {
            var token = await localStorageService.GetItemAsStringAsync("AccessToken");

            var identity = new ClaimsIdentity();
            var cp = new ClaimsPrincipal(identity);
            if (token != null)
            {
              identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "JWT");
              cp= new ClaimsPrincipal(identity);
            }
            return cp;
        }



        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(jwt);

            return jwtToken.Claims;
        }

        public async Task UserLoginAync()
        {

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(await ClaimsPrincipalAsync())));
        }

        public async Task UserLogoutAsync()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
            await localStorageService.RemoveItemAsync("AccessToken");
        }
    }
}
