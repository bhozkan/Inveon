using InveonWebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InveonWebUI.Business
{
    public class SignInBusiness
    {
        public async Task<string> LoginUser(LoginViewModel user)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    string AccessToken = "";
                    client.BaseAddress = new Uri("http://localhost:5000/api/");
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    var data = JsonConvert.SerializeObject(user);               
                    requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync("Auth/Login", requestMessage.Content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        AccessToken = await response.Content.ReadAsStringAsync();
                        AccessToken = JsonConvert.DeserializeObject<string>(AccessToken);
                        if (AccessToken == "") { AccessToken = null; }
                        return AccessToken;
                    }
                    else { return AccessToken; }

                }

            }
            catch (Exception ex)
            {
                throw;

            }
        }

    }
}
