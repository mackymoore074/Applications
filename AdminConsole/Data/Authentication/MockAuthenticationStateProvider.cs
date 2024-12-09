using ClassLibrary.DtoModels.Auth;
using ClassLibrary.DtoModels.Common;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text.Json;
using Blazorl

namespace AdminConsole.Data.Authentication
{
    public class MockAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public MockAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var identity = string.IsNullOrEmpty(token) ? new ClaimsIdentity() : new ClaimsIdentity(ParseClaimsFromJwt(token), "Bearer");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task MarkUserAsAuthenticated(string email, string password)
        {
            var loginDto = new LoginDto { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponseDto>>();
                var token = authResponse?.Data?.Token;
                if (token != null)
                {
                    await _localStorage.SetItemAsync("authToken", token);

                    var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "Bearer");
                    var user = new ClaimsPrincipal(identity);
                    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
                }
            }
        }

        public Task MarkUserAsLoggedOut()
        {
            _localStorage.RemoveItemAsync("authToken");
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));

            return Task.CompletedTask;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = WebEncoders.Base64UrlDecode(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }
    }

}
