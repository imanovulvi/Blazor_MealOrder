using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace MealOrder.ClientServer.AppClasses
{
    public class CuntomAuthenticationState : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IConfiguration configuration;

        public CuntomAuthenticationState(ILocalStorageService localStorageService, IConfiguration configuration)
        {
            this.localStorageService = localStorageService;
            this.configuration = configuration;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            return new AuthenticationState(await ClaimsPrincipalAsync());
        }

        async Task<ClaimsPrincipal> ClaimsPrincipalAsync()
        {
            ClaimsPrincipal cp = new ClaimsPrincipal();
            try
            {
              
                var token = await localStorageService.GetItemAsStringAsync("AccessToken");
                if (token is not null)
                {
                    cp.AddIdentity(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
                }
              
            }
            catch (Exception)
            {

            }
            return cp;
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

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(jwt);

            return jwtToken.Claims;
        }
    }
}
