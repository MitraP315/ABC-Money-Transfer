using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ABCExchange.Controllers
{
    [ApiExplorerSettings(GroupName = "access-control")]
    public class LoginApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("t/g")]
        public async Task<dynamic> G()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44335/connect/token");

            if (User.Identity.IsAuthenticated)
            {


                var keyValues = new List<KeyValuePair<string, string>>();
                keyValues.Add(new KeyValuePair<string, string>("client_id", "ro.finplus.internal"));
                // keyValues.Add(new KeyValuePair<string, string>("client_secret", "password"));
                keyValues.Add(new KeyValuePair<string, string>("grant_type", OidcConstants.GrantTypes.Password));
                keyValues.Add(new KeyValuePair<string, string>("username", User.Identity.GetUserName()));
                keyValues.Add(new KeyValuePair<string, string>("password", "dummy"));
                keyValues.Add(new KeyValuePair<string, string>("originrequest", "internal"));

                request.Content = new FormUrlEncodedContent(keyValues);
                var response = await client.SendAsync(request);
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(data);
            }
            else
            {

                var keyValues = new List<KeyValuePair<string, string>>();
                keyValues.Add(new KeyValuePair<string, string>("client_id", "client"));
                keyValues.Add(new KeyValuePair<string, string>("client_secret", "secret"));
                keyValues.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                request.Content = new FormUrlEncodedContent(keyValues);
                var response = await client.SendAsync(request);

                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(data);

            }

        }
    }
}
